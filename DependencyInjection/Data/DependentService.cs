namespace DependencyInjection.Data;

public class DependentService
{
    public ServiceWithCustomData ServiceWithCustomData { get; set; }

    public DependentService(ServiceWithCustomData serviceWithCustomData)
    {
        ServiceWithCustomData = serviceWithCustomData;
    }
}