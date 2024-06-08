﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.OrderDtos.AddressDtos;

public class CreateAddressDto
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostCode { get; set; }
    public string Detail { get; set; }
    public string Detail2 { get; set; }
}
