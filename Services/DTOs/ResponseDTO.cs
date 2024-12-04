namespace OL_TEST.DTOs
{
    public class ResponseDTO<T>
    {
        /// <summary>
        /// Código de estado HTTP de la respuesta.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Mensaje descriptivo de la operación.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Resultado genérico de la operación (puede ser null).
        /// </summary>
        public T? Result { get; set; }
    }
}
