namespace Transaction.Framework.Mappers
{
    using AutoMapper;
    using Transaction.Framework.Domain;
    using Transaction.Framework.DTO;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrencyDTO,Currency>();
        }
    }
}
