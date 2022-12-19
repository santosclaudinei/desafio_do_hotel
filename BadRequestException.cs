namespace DesafioProjetoHospedagem;

public class BadRequestException : Exception
{
	public BadRequestException(string errorMessage) : base(errorMessage) { }
}