﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.CatalogDtos.SpecialOfferDtos;

public class ResultSpecialOfferDto
{
    public string Id { get; set; }
    public int DiscountRate { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
}
