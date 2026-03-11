using AutoMapper;

namespace TrackFocus.Infraestructure.Data
{
    public class DAL<T> where T : class
    {
        private readonly AppDbContext _appContext;
        private readonly IMapper _mapper;

        public DAL(AppDbContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public List<T> Listar()
        {
            return _appContext.Set<T>().ToList();
        }

        public T? ListarPorId(Func<T, bool> condicao)
        {
            return _appContext.Set<T>().FirstOrDefault(condicao);
        }

        public void Adicionar(T objeto)
        {
            _appContext.Set<T>().Add(objeto);
            _appContext.SaveChanges();
        }
        public void Atualizar(T objeto)
        {
            _appContext.Set<T>().Update(objeto);
            _appContext.SaveChanges();
        }

        public void Deletar(T objeto)
        {
            _appContext.Set<T>().Remove(objeto);
            _appContext.SaveChanges();
        }

        public T ConverterEmEntidade<TRequest>(TRequest objeto)
        {
            return _mapper.Map<T>(objeto);
        }

        public List<T> ListaParaEntidade<TRequest>(List<TRequest> lista)
        {
            List<T> listaConvertida = new List<T>();
            foreach(var objeto in lista)
            {
                var objetoConvertido = ConverterEmEntidade<TRequest>(objeto);
                listaConvertida.Add(objetoConvertido);
            }

            return listaConvertida;
        }

        public TResponse ConverterEmResposta<TResponse>(T objeto)
        {
            return _mapper.Map<TResponse>(objeto);
        }

        public List<TResponse> ListaParaResposta<TResponse>(List<T> lista)
        {
            List<TResponse> listaConvertida = new List<TResponse>();
            foreach(var objeto in lista)
            {
                var objetoConvertido = ConverterEmResposta<TResponse>(objeto);
                listaConvertida.Add(objetoConvertido);
            }

            return listaConvertida;
        }            
    }
}