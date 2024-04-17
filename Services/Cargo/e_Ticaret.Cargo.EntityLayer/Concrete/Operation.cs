namespace e_Ticaret.Cargo.EntityLayer.Concrete;

public class Operation
{
    public int Id { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}
