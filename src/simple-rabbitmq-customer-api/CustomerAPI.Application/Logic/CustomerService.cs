﻿using AutoMapper;
using CustomerAPI.Core.Contract.Logic;
using CustomerAPI.Core.Entities;
using CustomerAPI.Core.Resources;
using CustomerAPI.Core.ValueObjects.Customers;
using FluentValidation;
using Mvp24Hours.Application.Logic;
using Mvp24Hours.Core.Contract.Data;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.Enums;
using Mvp24Hours.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerAPI.Application.Logic
{
    public class CustomerService(IUnitOfWorkAsync unitOfWork, IValidator<Customer> validator, IMapper mapper) : RepositoryPagingServiceAsync<Customer, IUnitOfWorkAsync>(unitOfWork, validator), ICustomerService
    {
        #region [ Queries ]

        public async Task<IPagingResult<IList<CustomerResult>>> GetBy(CustomerQuery dto, IPagingCriteria criteria, CancellationToken cancellationToken = default)
        {
            // apply filter default
            Expression<Func<Customer, bool>> clause =
                x => (string.IsNullOrEmpty(dto.Name) || x.Name.Contains(dto.Name))
                    && (dto.Active == null || dto.Active.Value);

            // try to get paginated data with criteria
            var result = await GetByWithPaginationAsync(clause, criteria, cancellationToken: cancellationToken);

            // checks if there are any records in the database from the filter
            if (result?.Summary != null && result.Summary.TotalCount == 0)
            {
                // reply with standard message for record not found
                return Messages.RECORD_NOT_FOUND
                    .ToMessageResult(nameof(Messages.RECORD_NOT_FOUND), MessageType.Error)
                    .ToBusinessPaging<IList<CustomerResult>>();
            }

            // apply filter with pagination
            return mapper.MapPagingTo<IList<Customer>, IList<CustomerResult>>(result);
        }

        public async Task<IBusinessResult<CustomerIdResult>> GetById(int id, CancellationToken cancellationToken = default)
        {
            // try to retrieve identifier with navigation property
            return await mapper
                .MapBusinessToAsync<Customer, CustomerIdResult>(GetByIdAsync(id, cancellationToken));
        }

        #endregion

        #region [ Commands ]

        public async Task<IBusinessResult<int>> Create(CustomerCreate dto, CancellationToken cancellationToken = default)
        {
            var entity = mapper.Map<Customer>(dto);

            // apply data validation to the model/entity with FluentValidation or DataAnnotation
            var errors = entity.TryValidate(Validator);
            if (errors.AnySafe())
            {
                return errors.ToBusiness<int>();
            }

            // perform create action on the database
            await Repository.AddAsync(entity, cancellationToken: cancellationToken);
            if (await UnitOfWork.SaveChangesAsync(cancellationToken: cancellationToken) > 0)
            {
                return entity.Id.ToBusiness(
                    Messages.OPERATION_SUCCESS
                        .ToMessageResult(nameof(Messages.OPERATION_SUCCESS), MessageType.Success));
            }

            // unknown error
            return Messages.OPERATION_FAIL
                .ToMessageResult(nameof(Messages.OPERATION_FAIL), MessageType.Error)
                .ToBusiness<int>();
        }

        public async Task<IBusinessResult<int>> Update(int id, CustomerUpdate dto, CancellationToken cancellationToken = default)
        {
            // gets entity through the identifier informed in the resource
            var entity = await Repository.GetByIdAsync(id, cancellationToken: cancellationToken);
            if (entity == null)
            {
                return Messages.RECORD_NOT_FOUND_FOR_ID
                    .ToMessageResult(nameof(Messages.RECORD_NOT_FOUND_FOR_ID), MessageType.Error)
                        .ToBusiness<int>();
            }

            // entity populating with DTO properties
            mapper.Map(dto, entity);

            // apply data validation to the model/entity with FluentValidation or DataAnnotation
            var errors = entity.TryValidate(Validator);
            if (errors.AnySafe())
            {
                return errors.ToBusiness<int>();
            }

            // apply changes to database
            await Repository.ModifyAsync(entity, cancellationToken: cancellationToken);
            int affectedRows = await UnitOfWork.SaveChangesAsync(cancellationToken: cancellationToken);
            if (affectedRows > 0)
            {
                return affectedRows.ToBusiness(
                    Messages.OPERATION_SUCCESS
                        .ToMessageResult(nameof(Messages.OPERATION_SUCCESS), MessageType.Success));
            }

            // unknown error
            return Messages.OPERATION_FAIL
                .ToMessageResult(nameof(Messages.OPERATION_FAIL), MessageType.Error)
                .ToBusiness<int>();
        }

        public async Task<IBusinessResult<int>> Delete(int id, CancellationToken cancellationToken = default)
        {
            // try to retrieve entity by identifier
            var entity = await Repository.GetByIdAsync(id, cancellationToken: cancellationToken);
            if (entity == null)
            {
                return Messages.RECORD_NOT_FOUND_FOR_ID
                    .ToMessageResult(nameof(Messages.RECORD_NOT_FOUND_FOR_ID), MessageType.Error)
                        .ToBusiness<int>();
            }

            // performs delete action on the database
            await Repository.RemoveAsync(entity, cancellationToken: cancellationToken);
            int affectedRows = await UnitOfWork.SaveChangesAsync(cancellationToken: cancellationToken);
            if (affectedRows > 0)
            {
                return affectedRows.ToBusiness(
                    Messages.OPERATION_SUCCESS
                        .ToMessageResult(nameof(Messages.OPERATION_SUCCESS), MessageType.Success));
            }

            // unknown error
            return Messages.OPERATION_FAIL
                .ToMessageResult(nameof(Messages.OPERATION_FAIL), MessageType.Error)
                .ToBusiness<int>();
        }

        #endregion
    }
}