using ThucTap.Entity;
using ThucTap.Payloads.DTOs;

namespace ThucTap.Payloads.Converters
{
    public class DecentrailizationConverter
    {
        private readonly AppDbContext _appDbContext;
        private readonly AccountConverter _accountConverter;
        public DecentrailizationConverter()
        {
            _appDbContext = new AppDbContext();
            _accountConverter = new AccountConverter();
        }
        public DecentralizationDTO EntityToDTO(Decentralization decentralization)
        {
            return new DecentralizationDTO
            {
                Authority_name = decentralization.Authority_name,
                decentralization_id = decentralization.decentralization_id,
                accounts = _appDbContext.Accounts.Where(x => x.DecentralizationId == decentralization.decentralization_id)
                                                           .Select(x => _accountConverter.EntityToDTO(x))
            };
        }
    }
}
