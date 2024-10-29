﻿using MediatR;

namespace EventSchedulingAndRegistration.Application.Common.CQRS;
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}
