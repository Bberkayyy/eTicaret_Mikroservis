﻿
namespace e_Ticaret.Catalog.Dtos.ProductImageDtos;

public class UpdateProductImageRequestDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductImageUrl1 { get; set; }
    public string ProductImageUrl2 { get; set; }
    public string ProductImageUrl3 { get; set; }
}
