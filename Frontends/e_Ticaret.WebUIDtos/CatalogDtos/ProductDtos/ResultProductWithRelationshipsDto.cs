using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;

public class ResultProductWithRelationshipsDto
{
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
