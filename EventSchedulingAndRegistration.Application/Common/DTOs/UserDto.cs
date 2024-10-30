﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Application.Common.DTOs
{
    public record UserDto(Guid Id,string Email, string Name,PersonalInformationDto PersonalInformation);
}
