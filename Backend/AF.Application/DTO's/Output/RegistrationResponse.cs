﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Application.DTO_s.Output
{
    public record RegistrationResponse(bool Flag, string Message = null!) { }
}
