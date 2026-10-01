import React, { useState, useEffect } from 'react';
import { ArrowLeft, Save, Activity, User, ShieldAlert, Heart } from 'lucide-react';
import {
  PCRRecord,
  DISPOSITION_OPTIONS,
  CMS_LEVEL_OPTIONS,
  DESTINATION_TYPE_OPTIONS,
  PATIENT_POSITION_OPTIONS,
  GENDER_OPTIONS,
  RESP_EFFORT_OPTIONS,
  RHYTHM_OPTIONS,
  BP_METHOD_OPTIONS,
  HR_TYPE_OPTIONS,
  GCS_VERBAL_OPTIONS,
  GCS_MOTOR_OPTIONS,
  GCS_EYES_OPTIONS,
} from '../types/pcr';
import { PCRStorageService } from '../services/storage';

interface PCRCreateEditViewProps {
  recordId?: number;
  onNavigate: (tab: string, id?: number) => void;
  onShowMessage: (msg: string) => void;
}

export const PCRCreateEditView: React.FC<PCRCreateEditViewProps> = ({
  recordId,
  onNavigate,
  onShowMessage,
}) => {
  const isEditing = Boolean(recordId);

  // Form State
  const [formData, setFormData] = useState<Partial<PCRRecord>>({
    incidentNumber: Math.floor(10000000 + Math.random() * 90000000),
    disposition: 'Transported (Emergency)',
    sceneAddress: '',
    cmsLevel: 'Basic Life Support (BLS)',
    vehicleNumber: 101,
    incidentDate: new Date().toISOString().split('T')[0],
    unitNotified: '12:00',
    enRoute: '12:02',
    onScene: '12:08',
    transporting: '12:20',
    destination: '12:35',
    inService: '12:50',
    primaryCareProvider: 'Kevin Blanchard, Paramedic',
    ambulanceDriver: 'Marcus Vance, EMT-B',
    loadMileage: 5.0,
    destinationAddress: '',
    reason: '',
    type: 'Hospital (Emergency Room Bed)',
    ptPosition: 'Supine',
    primarySymptom: '',
    primaryImpression: '',
    secondaryImpression: '',
    alcDrugUse: 'None',
    pcrNarrative: '',
    reportingCrewMember: 'Kevin Blanchard, Paramedic',

    // Patient
    ptFirstName: '',
    ptLastName: '',
    ptAge: 45,
    ptDateOfBirth: '1980-01-01',
    ptGender: 'Male',
    ptWeight: 75,
    patientAddress: '',
    ptPhoneNumber: '',
    ptSSN: '',
    ptHistory: 'None reported',
    ptAdvanceDirectives: 'Full Code',
    ptAllergiesMeds: 'NKDA',
    ptAllergiesOther: 'None',
    ptMedications: 'None',

    // Vitals
    systolicBloodPressure: 120,
    diastolicBloodPressure: 80,
    heartRate: 75,
    respiratoryRate: 16,
    respEffort: 'Normal',
    rhythm: 'Normal',
    bpMethod: 'Manual-Auscultated',
    hrType: 'Pulse-Oximeter',
    oximetry: 98,
    gcsVerbal: '5',
    gcsMotor: '6',
    gcsEyes: '4',
    bloodGlucose: 100,
    temperature: 98.6,
    vitalSignsTime: '12:10',
  });

  const [activeSection, setActiveSection] = useState<'incident' | 'patient' | 'vitals'>('incident');
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    if (recordId) {
      const existing = PCRStorageService.getPCRById(recordId);
      if (existing) {
        setFormData(existing);
      } else {
        setErrorMessage(`Patient Care Report #${recordId} not found.`);
      }
    }
  }, [recordId]);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>
  ) => {
    const { name, value, type } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: type === 'number' ? (value === '' ? 0 : Number(value)) : value,
    }));
  };

  // Calculated properties
  const meanPressure = Math.round(
    ((formData.systolicBloodPressure || 0) + (formData.diastolicBloodPressure || 0)) / 2
  );
  const gcsTotal =
    Number(formData.gcsEyes || 4) +
    Number(formData.gcsMotor || 6) +
    Number(formData.gcsVerbal || 5);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setErrorMessage('');

    // Basic Validation
    if (!formData.incidentNumber) {
      setErrorMessage('Incident Number is required.');
      return;
    }
    if (!formData.sceneAddress?.trim()) {
      setErrorMessage('Scene Address is required.');
      return;
    }
    if (!formData.ptFirstName?.trim() || !formData.ptLastName?.trim()) {
      setErrorMessage('Patient First and Last Name are required.');
      return;
    }
    if (!formData.pcrNarrative?.trim()) {
      setErrorMessage('PCR Narrative is required.');
      return;
    }

    try {
      if (isEditing && recordId) {
        const ok = PCRStorageService.updatePCR(recordId, formData);
        if (ok) {
          onShowMessage('Your PCR was updated.');
          onNavigate('pcr-list');
        } else {
          setErrorMessage('Your PCR could not be updated.');
        }
      } else {
        PCRStorageService.createPCR(formData as any);
        onShowMessage('Your PCR was created.');
        onNavigate('pcr-list');
      }
    } catch {
      setErrorMessage('Error saving Patient Care Report. Please check required values.');
    }
  };

  return (
    <div className="space-y-6 max-w-5xl mx-auto">
      <div className="flex items-center justify-between pb-3 border-b border-slate-300">
        <div className="flex items-center space-x-3">
          <button
            onClick={() => onNavigate('pcr-list')}
            className="p-2 rounded-full hover:bg-slate-200 text-slate-700 transition cursor-pointer"
            title="Back to List"
          >
            <ArrowLeft className="w-5 h-5" />
          </button>
          <h2 className="text-2xl sm:text-3xl font-bold text-slate-900">
            {isEditing ? `Edit PCR #${formData.incidentNumber}` : 'Create Patient Care Report'}
          </h2>
        </div>
        <button
          onClick={() => onNavigate('pcr-list')}
          className="text-sm font-semibold text-blue-700 hover:underline cursor-pointer"
        >
          Back to List
        </button>
      </div>

      {errorMessage && (
        <div className="p-4 bg-red-50 border border-red-300 rounded text-red-700 text-sm flex items-center gap-2">
          <ShieldAlert className="w-5 h-5 text-red-600 shrink-0" />
          <span>{errorMessage}</span>
        </div>
      )}

      {/* Section Nav Tabs */}
      <div className="flex border-b border-slate-300 bg-white rounded-t-lg overflow-x-auto shadow-xs">
        <button
          type="button"
          onClick={() => setActiveSection('incident')}
          className={`px-5 py-3 text-sm font-semibold border-b-2 flex items-center gap-2 transition cursor-pointer ${
            activeSection === 'incident'
              ? 'border-blue-600 text-blue-600 bg-blue-50/50'
              : 'border-transparent text-slate-600 hover:text-slate-900'
          }`}
        >
          <Activity className="w-4 h-4" />
          1. Incident & Transport
        </button>
        <button
          type="button"
          onClick={() => setActiveSection('patient')}
          className={`px-5 py-3 text-sm font-semibold border-b-2 flex items-center gap-2 transition cursor-pointer ${
            activeSection === 'patient'
              ? 'border-blue-600 text-blue-600 bg-blue-50/50'
              : 'border-transparent text-slate-600 hover:text-slate-900'
          }`}
        >
          <User className="w-4 h-4" />
          2. Patient Demographics & History
        </button>
        <button
          type="button"
          onClick={() => setActiveSection('vitals')}
          className={`px-5 py-3 text-sm font-semibold border-b-2 flex items-center gap-2 transition cursor-pointer ${
            activeSection === 'vitals'
              ? 'border-blue-600 text-blue-600 bg-blue-50/50'
              : 'border-transparent text-slate-600 hover:text-slate-900'
          }`}
        >
          <Heart className="w-4 h-4" />
          3. Vitals, GCS & Narrative
        </button>
      </div>

      <form onSubmit={handleSubmit} className="bg-white p-6 rounded-b-lg border border-slate-300 shadow-sm space-y-6">
        {/* SECTION 1: INCIDENT & TRANSPORT */}
        {activeSection === 'incident' && (
          <div className="space-y-6 animate-fadeIn">
            <h3 className="text-lg font-bold text-slate-800 border-b pb-2 flex items-center gap-2">
              <Activity className="w-5 h-5 text-blue-600" />
              Incident Demographics & Dispatch
            </h3>

            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Incident # <span className="text-red-500">*</span>
                </label>
                <input
                  type="number"
                  name="incidentNumber"
                  value={formData.incidentNumber || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Incident Date <span className="text-red-500">*</span>
                </label>
                <input
                  type="date"
                  name="incidentDate"
                  value={formData.incidentDate || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Vehicle # <span className="text-red-500">*</span>
                </label>
                <input
                  type="number"
                  name="vehicleNumber"
                  value={formData.vehicleNumber || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Disposition / Outcome <span className="text-red-500">*</span>
                </label>
                <select
                  name="disposition"
                  value={formData.disposition || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm bg-white focus:ring-2 focus:ring-blue-500 focus:outline-none"
                >
                  {DISPOSITION_OPTIONS.map((opt) => (
                    <option key={opt} value={opt}>
                      {opt}
                    </option>
                  ))}
                </select>
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  CMS Level <span className="text-red-500">*</span>
                </label>
                <select
                  name="cmsLevel"
                  value={formData.cmsLevel || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm bg-white focus:ring-2 focus:ring-blue-500 focus:outline-none"
                >
                  {CMS_LEVEL_OPTIONS.map((opt) => (
                    <option key={opt} value={opt}>
                      {opt}
                    </option>
                  ))}
                </select>
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Destination Type <span className="text-red-500">*</span>
                </label>
                <select
                  name="type"
                  value={formData.type || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm bg-white focus:ring-2 focus:ring-blue-500 focus:outline-none"
                >
                  {DESTINATION_TYPE_OPTIONS.map((opt) => (
                    <option key={opt} value={opt}>
                      {opt}
                    </option>
                  ))}
                </select>
              </div>
            </div>

            <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Scene Address <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="sceneAddress"
                  value={formData.sceneAddress || ''}
                  onChange={handleChange}
                  placeholder="e.g. 742 Evergreen Terrace"
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Destination Address <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="destinationAddress"
                  value={formData.destinationAddress || ''}
                  onChange={handleChange}
                  placeholder="e.g. Springfield Memorial Hospital"
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>
            </div>

            <h4 className="text-sm font-bold text-slate-700 border-b pb-1 pt-2">
              Dispatch & Run Timestamps
            </h4>
            <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-6 gap-3">
              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">Unit Notified</label>
                <input
                  type="time"
                  name="unitNotified"
                  value={formData.unitNotified || ''}
                  onChange={handleChange}
                  className="w-full p-1.5 border border-slate-300 rounded text-sm"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">En Route</label>
                <input
                  type="time"
                  name="enRoute"
                  value={formData.enRoute || ''}
                  onChange={handleChange}
                  className="w-full p-1.5 border border-slate-300 rounded text-sm"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">On Scene</label>
                <input
                  type="time"
                  name="onScene"
                  value={formData.onScene || ''}
                  onChange={handleChange}
                  className="w-full p-1.5 border border-slate-300 rounded text-sm"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">Transporting</label>
                <input
                  type="time"
                  name="transporting"
                  value={formData.transporting || ''}
                  onChange={handleChange}
                  className="w-full p-1.5 border border-slate-300 rounded text-sm"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">Destination</label>
                <input
                  type="time"
                  name="destination"
                  value={formData.destination || ''}
                  onChange={handleChange}
                  className="w-full p-1.5 border border-slate-300 rounded text-sm"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-600 mb-1">In Service</label>
                <input
                  type="time"
                  name="inService"
                  value={formData.inService || ''}
                  onChange={handleChange}
                  className="w-full p-1.5 border border-slate-300 rounded text-sm"
                />
              </div>
            </div>

            <div className="grid grid-cols-1 sm:grid-cols-3 gap-4 pt-2">
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Primary Care Provider <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="primaryCareProvider"
                  value={formData.primaryCareProvider || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Ambulance Driver <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="ambulanceDriver"
                  value={formData.ambulanceDriver || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Loaded Mileage <span className="text-red-500">*</span>
                </label>
                <input
                  type="number"
                  step="0.1"
                  name="loadMileage"
                  value={formData.loadMileage ?? ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                />
              </div>
            </div>

            <div className="flex justify-end pt-4">
              <button
                type="button"
                onClick={() => setActiveSection('patient')}
                className="px-5 py-2 bg-blue-600 text-white font-semibold rounded text-sm hover:bg-blue-700 cursor-pointer"
              >
                Next: Patient Info &rarr;
              </button>
            </div>
          </div>
        )}

        {/* SECTION 2: PATIENT DEMOGRAPHICS & HISTORY */}
        {activeSection === 'patient' && (
          <div className="space-y-6 animate-fadeIn">
            <h3 className="text-lg font-bold text-slate-800 border-b pb-2 flex items-center gap-2">
              <User className="w-5 h-5 text-blue-600" />
              Patient Demographics & Medical History
            </h3>

            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-4 gap-4">
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  First Name <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="ptFirstName"
                  value={formData.ptFirstName || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Last Name <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="ptLastName"
                  value={formData.ptLastName || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Age <span className="text-red-500">*</span>
                </label>
                <input
                  type="number"
                  name="ptAge"
                  value={formData.ptAge || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Date of Birth <span className="text-red-500">*</span>
                </label>
                <input
                  type="date"
                  name="ptDateOfBirth"
                  value={formData.ptDateOfBirth || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Gender <span className="text-red-500">*</span>
                </label>
                <select
                  name="ptGender"
                  value={formData.ptGender || 'Male'}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                >
                  {GENDER_OPTIONS.map((g) => (
                    <option key={g} value={g}>
                      {g}
                    </option>
                  ))}
                </select>
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Weight (kg) <span className="text-red-500">*</span>
                </label>
                <input
                  type="number"
                  step="0.1"
                  name="ptWeight"
                  value={formData.ptWeight || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Phone #
                </label>
                <input
                  type="tel"
                  name="ptPhoneNumber"
                  value={formData.ptPhoneNumber || ''}
                  onChange={handleChange}
                  placeholder="555-123-4567"
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  SSN
                </label>
                <input
                  type="text"
                  name="ptSSN"
                  value={formData.ptSSN || ''}
                  onChange={handleChange}
                  placeholder="***-**-1234"
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>
            </div>

            <div>
              <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                Patient Residence Address <span className="text-red-500">*</span>
              </label>
              <input
                type="text"
                name="patientAddress"
                value={formData.patientAddress || ''}
                onChange={handleChange}
                required
                className="w-full p-2 border border-slate-300 rounded text-sm"
              />
            </div>

            <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Medical History <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="ptHistory"
                  value={formData.ptHistory || ''}
                  onChange={handleChange}
                  placeholder="e.g. Hypertension, Diabetes, COPD"
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Advance Directives
                </label>
                <input
                  type="text"
                  name="ptAdvanceDirectives"
                  value={formData.ptAdvanceDirectives || ''}
                  onChange={handleChange}
                  placeholder="e.g. Full Code, DNR, Living Will"
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Allergies (Medications)
                </label>
                <input
                  type="text"
                  name="ptAllergiesMeds"
                  value={formData.ptAllergiesMeds || ''}
                  onChange={handleChange}
                  placeholder="e.g. Penicillin, Sulfa, NKDA"
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Allergies (Other / Environmental)
                </label>
                <input
                  type="text"
                  name="ptAllergiesOther"
                  value={formData.ptAllergiesOther || ''}
                  onChange={handleChange}
                  placeholder="e.g. Latex, Iodine, Bee stings"
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>
            </div>

            <div>
              <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                Current Patient Medications
              </label>
              <input
                type="text"
                name="ptMedications"
                value={formData.ptMedications || ''}
                onChange={handleChange}
                placeholder="e.g. Aspirin 81mg, Metoprolol 25mg"
                className="w-full p-2 border border-slate-300 rounded text-sm"
              />
            </div>

            <div className="flex justify-between pt-4">
              <button
                type="button"
                onClick={() => setActiveSection('incident')}
                className="px-5 py-2 bg-slate-200 text-slate-800 font-semibold rounded text-sm hover:bg-slate-300 cursor-pointer"
              >
                &larr; Previous: Incident
              </button>
              <button
                type="button"
                onClick={() => setActiveSection('vitals')}
                className="px-5 py-2 bg-blue-600 text-white font-semibold rounded text-sm hover:bg-blue-700 cursor-pointer"
              >
                Next: Vitals & Assessment &rarr;
              </button>
            </div>
          </div>
        )}

        {/* SECTION 3: VITALS, ASSESSMENT & NARRATIVE */}
        {activeSection === 'vitals' && (
          <div className="space-y-6 animate-fadeIn">
            <h3 className="text-lg font-bold text-slate-800 border-b pb-2 flex items-center gap-2">
              <Heart className="w-5 h-5 text-red-600" />
              Clinical Assessment, Vitals & Narrative
            </h3>

            {/* Assessment Impressions */}
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Reason for Transport / Call <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="reason"
                  value={formData.reason || ''}
                  onChange={handleChange}
                  placeholder="e.g. Chest pain with shortness of breath"
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Patient Position <span className="text-red-500">*</span>
                </label>
                <select
                  name="ptPosition"
                  value={formData.ptPosition || 'Supine'}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                >
                  {PATIENT_POSITION_OPTIONS.map((pos) => (
                    <option key={pos} value={pos}>
                      {pos}
                    </option>
                  ))}
                </select>
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Alcohol / Drug Suspected <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="alcDrugUse"
                  value={formData.alcDrugUse || ''}
                  onChange={handleChange}
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Primary Symptom <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="primarySymptom"
                  value={formData.primarySymptom || ''}
                  onChange={handleChange}
                  placeholder="e.g. Chest pain"
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Primary Impression <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="primaryImpression"
                  value={formData.primaryImpression || ''}
                  onChange={handleChange}
                  placeholder="e.g. Acute Coronary Syndrome"
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>

              <div>
                <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                  Secondary Impression <span className="text-red-500">*</span>
                </label>
                <input
                  type="text"
                  name="secondaryImpression"
                  value={formData.secondaryImpression || ''}
                  onChange={handleChange}
                  placeholder="e.g. Dyspnea, Hypertension"
                  required
                  className="w-full p-2 border border-slate-300 rounded text-sm"
                />
              </div>
            </div>

            {/* Vitals Set */}
            <div className="bg-slate-50 p-4 rounded border border-slate-200 space-y-4">
              <div className="flex items-center justify-between border-b pb-2">
                <h4 className="font-bold text-slate-800 text-sm">Vital Signs & Monitoring</h4>
                <div className="flex items-center gap-4 text-xs font-semibold">
                  <span className="text-slate-600 bg-white px-2 py-1 rounded border">
                    Mean Pressure: <strong className="text-blue-700">{meanPressure} mmHg</strong>
                  </span>
                  <span className="text-slate-600 bg-white px-2 py-1 rounded border">
                    GCS Total: <strong className="text-emerald-700">{gcsTotal} / 15</strong>
                  </span>
                </div>
              </div>

              <div className="grid grid-cols-2 sm:grid-cols-4 md:grid-cols-6 gap-3">
                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    Systolic BP <span className="text-red-500">*</span>
                  </label>
                  <input
                    type="number"
                    name="systolicBloodPressure"
                    value={formData.systolicBloodPressure || ''}
                    onChange={handleChange}
                    required
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    Diastolic BP <span className="text-red-500">*</span>
                  </label>
                  <input
                    type="number"
                    name="diastolicBloodPressure"
                    value={formData.diastolicBloodPressure || ''}
                    onChange={handleChange}
                    required
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    Heart Rate <span className="text-red-500">*</span>
                  </label>
                  <input
                    type="number"
                    name="heartRate"
                    value={formData.heartRate || ''}
                    onChange={handleChange}
                    required
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    Resp Rate <span className="text-red-500">*</span>
                  </label>
                  <input
                    type="number"
                    min="1"
                    max="80"
                    name="respiratoryRate"
                    value={formData.respiratoryRate || ''}
                    onChange={handleChange}
                    required
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    SpO2 (%) <span className="text-red-500">*</span>
                  </label>
                  <input
                    type="number"
                    min="1"
                    max="100"
                    name="oximetry"
                    value={formData.oximetry || ''}
                    onChange={handleChange}
                    required
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    Blood Glucose
                  </label>
                  <input
                    type="number"
                    name="bloodGlucose"
                    value={formData.bloodGlucose || ''}
                    onChange={handleChange}
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    Temp (°F)
                  </label>
                  <input
                    type="number"
                    step="0.1"
                    name="temperature"
                    value={formData.temperature || ''}
                    onChange={handleChange}
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">
                    Vitals Time <span className="text-red-500">*</span>
                  </label>
                  <input
                    type="time"
                    name="vitalSignsTime"
                    value={formData.vitalSignsTime || ''}
                    onChange={handleChange}
                    required
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  />
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">BP Method</label>
                  <select
                    name="bpMethod"
                    value={formData.bpMethod || 'Manual-Auscultated'}
                    onChange={handleChange}
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  >
                    {BP_METHOD_OPTIONS.map((m) => (
                      <option key={m} value={m}>
                        {m}
                      </option>
                    ))}
                  </select>
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">HR Type</label>
                  <select
                    name="hrType"
                    value={formData.hrType || 'Pulse-Oximeter'}
                    onChange={handleChange}
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  >
                    {HR_TYPE_OPTIONS.map((t) => (
                      <option key={t} value={t}>
                        {t}
                      </option>
                    ))}
                  </select>
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">Cardiac Rhythm</label>
                  <select
                    name="rhythm"
                    value={formData.rhythm || 'Normal'}
                    onChange={handleChange}
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  >
                    {RHYTHM_OPTIONS.map((r) => (
                      <option key={r} value={r}>
                        {r}
                      </option>
                    ))}
                  </select>
                </div>

                <div>
                  <label className="block text-xs font-semibold text-slate-700 mb-1">Resp Effort</label>
                  <select
                    name="respEffort"
                    value={formData.respEffort || 'Normal'}
                    onChange={handleChange}
                    className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                  >
                    {RESP_EFFORT_OPTIONS.map((re) => (
                      <option key={re} value={re}>
                        {re}
                      </option>
                    ))}
                  </select>
                </div>
              </div>

              {/* Glasgow Coma Scale (GCS) */}
              <div className="pt-2 border-t border-slate-200">
                <span className="block text-xs font-bold text-slate-700 mb-2 uppercase">
                  Glasgow Coma Scale (GCS)
                </span>
                <div className="grid grid-cols-1 sm:grid-cols-3 gap-3">
                  <div>
                    <label className="block text-xs font-semibold text-slate-600 mb-1">
                      GCS Verbal (1 - 5) <span className="text-red-500">*</span>
                    </label>
                    <select
                      name="gcsVerbal"
                      value={formData.gcsVerbal || '5'}
                      onChange={handleChange}
                      required
                      className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                    >
                      {GCS_VERBAL_OPTIONS.map((v) => (
                        <option key={v.value} value={v.value}>
                          {v.text}
                        </option>
                      ))}
                    </select>
                  </div>

                  <div>
                    <label className="block text-xs font-semibold text-slate-600 mb-1">
                      GCS Motor (1 - 6) <span className="text-red-500">*</span>
                    </label>
                    <select
                      name="gcsMotor"
                      value={formData.gcsMotor || '6'}
                      onChange={handleChange}
                      required
                      className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                    >
                      {GCS_MOTOR_OPTIONS.map((m) => (
                        <option key={m.value} value={m.value}>
                          {m.text}
                        </option>
                      ))}
                    </select>
                  </div>

                  <div>
                    <label className="block text-xs font-semibold text-slate-600 mb-1">
                      GCS Eyes (1 - 4) <span className="text-red-500">*</span>
                    </label>
                    <select
                      name="gcsEyes"
                      value={formData.gcsEyes || '4'}
                      onChange={handleChange}
                      required
                      className="w-full p-2 border border-slate-300 rounded text-sm bg-white"
                    >
                      {GCS_EYES_OPTIONS.map((e) => (
                        <option key={e.value} value={e.value}>
                          {e.text}
                        </option>
                      ))}
                    </select>
                  </div>
                </div>
              </div>
            </div>

            {/* PCR Narrative */}
            <div>
              <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                PCR Narrative (Detailed EMS Call Account) <span className="text-red-500">*</span>
              </label>
              <textarea
                name="pcrNarrative"
                rows={8}
                value={formData.pcrNarrative || ''}
                onChange={handleChange}
                placeholder="Include dispatch reason, patient position on arrival, physical findings, treatment interventions, medications given, response to treatment, and transfer of care..."
                required
                className="w-full p-3 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none leading-relaxed"
              />
            </div>

            <div>
              <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
                Reporting Crew Member <span className="text-red-500">*</span>
              </label>
              <input
                type="text"
                name="reportingCrewMember"
                value={formData.reportingCrewMember || ''}
                onChange={handleChange}
                required
                className="w-full sm:w-1/2 p-2 border border-slate-300 rounded text-sm"
              />
            </div>

            <div className="flex justify-between pt-4 border-t">
              <button
                type="button"
                onClick={() => setActiveSection('patient')}
                className="px-5 py-2 bg-slate-200 text-slate-800 font-semibold rounded text-sm hover:bg-slate-300 cursor-pointer"
              >
                &larr; Previous: Patient Info
              </button>

              <button
                type="submit"
                className="px-6 py-2.5 bg-blue-600 hover:bg-blue-700 text-white font-semibold text-sm rounded shadow hover:shadow-md transition flex items-center gap-2 cursor-pointer"
              >
                <Save className="w-4 h-4" />
                {isEditing ? 'Save Changes' : 'Create Report'}
              </button>
            </div>
          </div>
        )}
      </form>
    </div>
  );
};
