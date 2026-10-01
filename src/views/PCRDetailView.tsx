import React from 'react';
import { ArrowLeft, Edit3, Trash2, Printer } from 'lucide-react';
import { PCRStorageService } from '../services/storage';

interface PCRDetailViewProps {
  recordId: number;
  onNavigate: (tab: string, id?: number) => void;
}

export const PCRDetailView: React.FC<PCRDetailViewProps> = ({ recordId, onNavigate }) => {
  const pcr = PCRStorageService.getPCRById(recordId);

  if (!pcr) {
    return (
      <div className="max-w-4xl mx-auto p-8 text-center bg-white rounded border border-slate-300">
        <h2 className="text-xl font-bold text-red-600">Patient Care Report Not Found</h2>
        <p className="mt-2 text-slate-600">Could not find PCR with ID #{recordId}</p>
        <button
          onClick={() => onNavigate('pcr-list')}
          className="mt-4 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
        >
          Back to List
        </button>
      </div>
    );
  }

  const meanPressure = Math.round(((pcr.systolicBloodPressure || 0) + (pcr.diastolicBloodPressure || 0)) / 2);
  const gcsTotal = Number(pcr.gcsEyes || 0) + Number(pcr.gcsMotor || 0) + Number(pcr.gcsVerbal || 0);

  const fields = [
    { label: 'Date Created', value: pcr.dateCreated ? new Date(pcr.dateCreated).toLocaleString() : 'N/A' },
    { label: 'Date Modified', value: pcr.dateModified ? new Date(pcr.dateModified).toLocaleString() : 'N/A' },
    { label: 'Incident #', value: pcr.incidentNumber },
    { label: 'Disposition/Outcome', value: pcr.disposition },
    { label: 'Scene Address', value: pcr.sceneAddress },
    { label: 'CMS Level', value: pcr.cmsLevel },
    { label: 'Vehicle #', value: pcr.vehicleNumber },
    { label: 'Incident Date', value: pcr.incidentDate },
    { label: 'Unit Notified', value: pcr.unitNotified },
    { label: 'En Route', value: pcr.enRoute },
    { label: 'On Scene', value: pcr.onScene },
    { label: 'Transporting', value: pcr.transporting },
    { label: 'Destination', value: pcr.destination },
    { label: 'In Service', value: pcr.inService },
    { label: 'Primary Care Provider', value: pcr.primaryCareProvider },
    { label: 'Ambulance Driver', value: pcr.ambulanceDriver },
    { label: 'Load Mileage', value: `${pcr.loadMileage} miles` },
    { label: 'Destination Address', value: pcr.destinationAddress },
    { label: 'Reason', value: pcr.reason },
    { label: 'Type', value: pcr.type },
    { label: 'Pt Position', value: pcr.ptPosition },
    { label: 'Primary Symptom', value: pcr.primarySymptom },
    { label: 'Primary Impression', value: pcr.primaryImpression },
    { label: 'Secondary Impression', value: pcr.secondaryImpression },
    { label: 'Alc/Drug Use', value: pcr.alcDrugUse },
    { label: 'PCR Narrative', value: pcr.pcrNarrative, isLong: true },
    { label: 'Reporting Crew Member', value: pcr.reportingCrewMember },
    { label: 'Patient First Name', value: pcr.ptFirstName },
    { label: 'Patient Last Name', value: pcr.ptLastName },
    { label: 'Patient Age', value: `${pcr.ptAge} yrs` },
    { label: 'Patient Date Of Birth', value: pcr.ptDateOfBirth },
    { label: 'Patient Gender', value: pcr.ptGender },
    { label: 'Patient Weight (kg)', value: `${pcr.ptWeight} kg` },
    { label: 'Patient Address', value: pcr.patientAddress },
    { label: 'Patient Phone #', value: pcr.ptPhoneNumber || 'None' },
    { label: 'Patient SSN', value: pcr.ptSSN || 'N/A' },
    { label: 'Patient Medical History', value: pcr.ptHistory },
    { label: 'Patient Advance Directives', value: pcr.ptAdvanceDirectives || 'None' },
    { label: 'Patient Allergies (Meds)', value: pcr.ptAllergiesMeds || 'NKDA' },
    { label: 'Patient Allergies (Other)', value: pcr.ptAllergiesOther || 'None' },
    { label: 'Patient Medications', value: pcr.ptMedications || 'None' },
    { label: 'Systolic Blood Pressure', value: `${pcr.systolicBloodPressure} mmHg` },
    { label: 'Diastolic Blood Pressure', value: `${pcr.diastolicBloodPressure} mmHg` },
    { label: 'Mean Pressure', value: `${meanPressure} mmHg` },
    { label: 'Heart Rate', value: `${pcr.heartRate} bpm` },
    { label: 'Respiratory Rate', value: `${pcr.respiratoryRate} /min` },
    { label: 'Resp Effort', value: pcr.respEffort },
    { label: 'Rhythm', value: pcr.rhythm },
    { label: 'BP Method', value: pcr.bpMethod },
    { label: 'HR Type', value: pcr.hrType },
    { label: 'Oximetry (%)', value: `${pcr.oximetry}%` },
    { label: 'GCS (Verbal)', value: pcr.gcsVerbal },
    { label: 'GCS (Motor)', value: pcr.gcsMotor },
    { label: 'GCS (Eyes)', value: pcr.gcsEyes },
    { label: 'GCS (Total)', value: `${gcsTotal} / 15` },
    { label: 'Blood Glucose', value: `${pcr.bloodGlucose} mg/dL` },
    { label: 'Temperature (°F)', value: `${pcr.temperature} °F` },
    { label: 'Vital Signs (Time)', value: pcr.vitalSignsTime },
  ];

  return (
    <div className="space-y-6 max-w-5xl mx-auto">
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-2 border-b border-slate-300">
        <div className="flex items-center space-x-3">
          <button
            onClick={() => onNavigate('pcr-list')}
            className="p-2 rounded-full hover:bg-slate-200 text-slate-700 transition cursor-pointer"
            title="Back to List"
          >
            <ArrowLeft className="w-5 h-5" />
          </button>
          <div>
            <h2 className="text-2xl sm:text-3xl font-bold text-slate-900">
              Details - Incident #{pcr.incidentNumber}
            </h2>
            <p className="text-sm text-slate-500">
              Provider: {pcr.primaryCareProvider} | Patient: {pcr.ptLastName}, {pcr.ptFirstName}
            </p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          <button
            onClick={() => window.print()}
            className="px-3 py-1.5 border border-slate-300 bg-white hover:bg-slate-50 rounded text-slate-700 text-sm font-semibold flex items-center gap-1.5 cursor-pointer"
          >
            <Printer className="w-4 h-4" />
            Print Report
          </button>
          <button
            onClick={() => onNavigate('pcr-edit', pcr.patientCareReportId)}
            className="px-3 py-1.5 bg-blue-600 hover:bg-blue-700 text-white rounded text-sm font-semibold flex items-center gap-1.5 cursor-pointer"
          >
            <Edit3 className="w-4 h-4" />
            Edit
          </button>
          <button
            onClick={() => onNavigate('pcr-delete', pcr.patientCareReportId)}
            className="px-3 py-1.5 bg-red-600 hover:bg-red-700 text-white rounded text-sm font-semibold flex items-center gap-1.5 cursor-pointer"
          >
            <Trash2 className="w-4 h-4" />
            Delete
          </button>
        </div>
      </div>

      {/* Styled DL container matching original AmbulancePCR */}
      <div className="border-4 border-slate-400 bg-white shadow-md rounded overflow-hidden">
        <dl className="grid grid-cols-1 sm:grid-cols-12 divide-y divide-slate-300 text-sm">
          {fields.map((f, idx) => (
            <React.Fragment key={idx}>
              <dt className="sm:col-span-4 bg-neutral-800 text-white sm:text-right px-4 py-2 font-semibold flex items-center sm:justify-end">
                {f.label}
              </dt>
              <dd className="sm:col-span-8 bg-white px-4 py-2 text-slate-900 flex items-center leading-relaxed">
                {f.isLong ? (
                  <span className="whitespace-pre-wrap font-sans text-slate-800">{f.value || 'N/A'}</span>
                ) : (
                  <span>{f.value || 'N/A'}</span>
                )}
              </dd>
            </React.Fragment>
          ))}
        </dl>
      </div>

      <div className="pt-2 text-sm">
        <button
          onClick={() => onNavigate('pcr-list')}
          className="text-blue-700 hover:underline font-semibold cursor-pointer"
        >
          | Back to List |
        </button>
      </div>
    </div>
  );
};
