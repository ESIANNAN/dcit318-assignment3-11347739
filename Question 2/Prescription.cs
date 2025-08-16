public void PrintPrescriptionsForPatient(int patientId)
{
    // fetches the patient from the repository
    var patient = _patientRepo.GetById(p => p.Id == patientId);
    
    if (patient == null)
    {
        Console.WriteLine($"No patient found with ID {patientId}");
        return;
    }

    Console.WriteLine($"\nPrescriptions for {patient.Name}:");

    // Get the list of prescriptions for this patient from the map
    var prescriptions = GetPrescriptionsByPatientId(patientId);

    if (prescriptions.Count == 0)
    {
        Console.WriteLine("No prescriptions found for this patient.");
        return;
    }

    // Print each prescription
    foreach (var p in prescriptions)
    {
        Console.WriteLine($"- {p.MedicationName} (Issued: {p.DateIssued.ToShortDateString()})");
    }
}
