namespace crud_dotnet_api.Data
{
	public class DataResult<T>
	{

		public int Code { get; set; }
		public string Message { get; set; }

		public T Data { get; set; }

		public DataResult(int code ,string message, T data )
		{
			Code = code;
			Message = message;
			Data = data;
		}


}
}
