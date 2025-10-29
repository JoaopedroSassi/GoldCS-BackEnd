namespace GoldCS.Domain.Util
{

    public enum OrderStatus
    {
        Received = 1,
        Paid = 2,
        InTransport = 3,
        Delivered = 4,
        Archived = 5,
        Canceled = 6,
    }

    public enum AdressType
    {
        Comercial = 1, 
        Residential = 2,
    }

}
