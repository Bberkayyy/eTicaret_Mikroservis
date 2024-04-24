using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.CatalogDtos.ProductImageDtos;

public class ResultProductImageWithRelationshipsByProductIdDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductImageUrl1 { get; set; }
    public string ProductImageUrl2 { get; set; }
    public string ProductImageUrl3 { get; set; }
}
