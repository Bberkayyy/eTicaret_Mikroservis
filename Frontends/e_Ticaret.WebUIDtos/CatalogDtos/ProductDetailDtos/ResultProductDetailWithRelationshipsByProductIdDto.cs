using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.CatalogDtos.ProductDetailDtos;

public class ResultProductDetailWithRelationshipsByProductIdDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
}
