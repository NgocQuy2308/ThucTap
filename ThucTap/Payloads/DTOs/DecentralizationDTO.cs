using ThucTap.Entity;

namespace ThucTap.Payloads.DTOs
{
    public class DecentralizationDTO
    {
        public int decentralization_id { get; set; }
        public string Authority_name { get; set; }
        public IQueryable<AccountDTO>? accounts { get; set; }

    }
}
