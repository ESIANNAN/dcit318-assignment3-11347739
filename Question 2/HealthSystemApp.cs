using System;
using System.Collections.Generic;

public class HealthSystemApp
{
    private Repository<Patient> _patientRepo = new Repository<Patient>();
    private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
    private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

    public void SeedData()
    {
        _patientRepo.Add(new Patient(1, "Alice Johnson", 30, "Female"));
        _patientRepo.Add(new Patient(2, "Bob Smith", 45, "Male"));
        _patientRepo.Add(new Patient(3, "Charlie Lee", 28, "Male"));

        _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-10)));
        _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-5)));
        _prescriptionRepo.Add(new Prescription(3, 2, "Metformin", DateTime.Now.AddDays(-7)));
        _prescriptionRepo.Add(new Prescription(4, 3, "Lisinopril", DateTime.Now.AddDays(-2)));
        _prescriptionRepo.Add(new Prescription(5, 2, "Atorvastatin", DateTime.Now.AddDays(-1)));
    }

    public void BuildPrescriptionMap()
    {
        _prescriptionMap.Clear();
        foreach (var prescription in _prescriptionRepo.GetAll())
        {
            if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                _prescriptionMap[prescription.PatientId] = new List<Prescription>();

            _prescriptionMap[prescription.PatientId].Add(prescription);
        }
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("Patients:");
        foreach (var patient in _patientRepo.GetAll())
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
        Console.WriteLine();
    }

    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        if (_prescriptionMap.ContainsKey(patientId))
            return _prescriptionMap[patientId];
        return new List<Prescription>();
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
        var patient = _patientRepo.GetById(p => p.Id == patientId);
        if (patient == null) { Console.WriteLine($"No patient found with ID {patientId}"); return; }

        Console.WriteLine($"\nPrescriptions for {patient.Name}:");
        var prescriptions = GetPrescriptionsByPatientId(patientId);
        if (prescriptions.Count == 0) { Console.WriteLine("No prescriptions found."); return; }

        foreach (var p in prescriptions)
            Console.WriteLine($"- {p.MedicationName} (Issued: {p.DateIssued.ToShortDateString()})");
    }
}

