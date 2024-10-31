using SampleWebApi.Model;

namespace SampleWebApi.Repository
{
    public class FabricantesRepository : UnitOfWork<Fabricante>, 
                                         IFabricanteRepository
    {
        public FabricantesRepository(SampleContext context) 
            : base(context)
        {
        }
    }
}
