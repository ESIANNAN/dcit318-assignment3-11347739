
class Program
{
    static void Main()
    {
        HealthSystemApp app = new HealthSystemApp();

        app.SeedData();
        app.BuildPrescriptionMap();
        app.PrintAllPatients();

        // example is displaying prescriptions for patient with ID = 2
        app.PrintPrescriptionsForPatient(2);
    }
}
