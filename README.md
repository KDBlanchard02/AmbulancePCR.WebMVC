# AmbulancePCR

AmbulancePCR is a web-based Electronic Patient Care Report (ePCR) and Quality Assurance (QA) documentation platform for Emergency Medical Services (EMS) professionals. It allows paramedics, EMTs, and EMS agencies to document comprehensive pre-hospital clinical assessments, dispatch timestamps, patient demographics, vital signs, call narratives, and supervisory QA audit reviews.

## Features

- **Patient Care Reports (ePCR)**:
  - Incident Demographics: Incident number, date, vehicle number, CMS Level (BLS, ALS1, ALS2, SCT, PI), disposition outcome, scene & destination addresses, loaded mileage, patient transport position.
  - Dispatch & En Route Timestamps: Unit notified, en route, on scene, transporting, destination arrival, and in service.
  - Patient Demographics & History: First/last name, DOB, age, gender, weight (kg), phone, SSN, medical history, advance directives, allergies (medications and other), current medications.
  - Vital Signs & Assessment: Systolic & diastolic blood pressure with automatic Mean Arterial Pressure (MAP) calculation, heart rate, cardiac rhythm, respiratory rate & effort, SpO2 oximetry, blood glucose, temperature, BP/HR methods, and Glasgow Coma Scale (GCS Eyes, Verbal, Motor) with automatic GCS total calculation.
  - PCR Narrative: Detailed EMS call account and reporting crew member documentation.
  - Full CRUD operations: Create, View Details, Edit, and Delete reports with printable formatted reports.
- **Quality Assurance (QA) Module**:
  - Supervisor QA audits linked by Incident number.
  - Real-time resolution tracking (Pending Review vs. Resolved status).
  - Cross-referencing to patient last name and primary care provider.
  - Full CRUD workflows for supervisory auditing.
- **Responsive Web UI**: Built with React, TypeScript, and Tailwind CSS, preserving the original Star of Life branding and layout.

## Getting Started

Run the development server on port 3000:

```bash
npm install
npm run dev
```

Build for production:

```bash
npm run build
```
