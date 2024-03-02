using TCKNService;

namespace Core.Utilities.Verification.TCKN;

public class TCKNVerificationService : IVerificationService
{
    public async Task<bool> VerifyTCKN(long tckn, string ad, string soyad, int dogumYili)
    {
        KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);

        var response = await client.TCKimlikNoDogrulaAsync(tckn, ad, soyad, dogumYili);

        return response.Body.TCKimlikNoDogrulaResult;
    }
}
