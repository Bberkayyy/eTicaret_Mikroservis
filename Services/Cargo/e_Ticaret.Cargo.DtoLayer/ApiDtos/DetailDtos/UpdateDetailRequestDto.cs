namespace e_Ticaret.Cargo.DtoLayer.ApiDtos.DetailDtos;

public class UpdateDetailRequestDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Sender { get; set; }
    public string ReceiverId { get; set; }
    public string BarcodeNo { get; set; }
}
