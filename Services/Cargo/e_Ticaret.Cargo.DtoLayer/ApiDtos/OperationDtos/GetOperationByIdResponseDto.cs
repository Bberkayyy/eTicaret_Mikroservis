namespace e_Ticaret.Cargo.DtoLayer.ApiDtos.OperationDtos;

public class GetOperationByIdResponseDto
{
    public int Id { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}
