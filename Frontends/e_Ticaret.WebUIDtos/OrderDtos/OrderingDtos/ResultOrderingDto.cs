﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.OrderDtos.OrderingDtos;

public class ResultOrderingDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
