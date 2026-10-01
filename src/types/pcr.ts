export interface Incident {
  patientCareReportId: number;
  authorId: string;
  dateCreated: string;
  dateModified: string;
  incidentNumber: number;
  disposition: string;
  sceneAddress: string;
  cmsLevel: string;
  vehicleNumber: number;
  incidentDate: string; // YYYY-MM-DD
  unitNotified: string; // HH:mm:ss or HH:mm
  enRoute: string;
  onScene: string;
  transporting: string;
  destination: string;
  inService: string;
  primaryCareProvider: string;
  ambulanceDriver: string;
  loadMileage: number;
  destinationAddress: string;
  reason: string;
  type: string;
  ptPosition: string;
  primarySymptom: string;
  primaryImpression: string;
  secondaryImpression: string;
  alcDrugUse: string;
  pcrNarrative: string;
  reportingCrewMember: string;
}

export interface PatientInformation {
  patientId?: number;
  incidentNumber: number;
  ptFirstName: string;
  ptLastName: string;
  ptAge: number;
  ptDateOfBirth: string; // YYYY-MM-DD
  ptGender: string;
  ptWeight: number; // in kg
  patientAddress: string;
  ptPhoneNumber: string;
  ptSSN: string;
  ptHistory: string;
  ptAdvanceDirectives: string;
  ptAllergiesMeds: string;
  ptAllergiesOther: string;
  ptMedications: string;
}

export interface Vitals {
  vitalsId?: number;
  incidentNumber: number;
  systolicBloodPressure: number;
  diastolicBloodPressure: number;
  meanPressure?: number;
  heartRate: number;
  respiratoryRate: number;
  respEffort: string;
  rhythm: string;
  bpMethod: string;
  hrType: string;
  oximetry: number;
  gcsVerbal: string;
  gcsMotor: string;
  gcsEyes: string;
  gcsTotal?: number;
  bloodGlucose: number;
  temperature: number; // °F
  vitalSignsTime: string; // HH:mm
}

export interface PCRRecord extends Incident, Omit<PatientInformation, 'incidentNumber'>, Omit<Vitals, 'incidentNumber'> {
  // Combined model representing a complete Patient Care Report
}

export interface PCRListItem {
  patientCareReportId: number;
  primaryCareProvider: string;
  incidentDate: string;
  incidentNumber: number;
}

export interface QAIssue {
  issueId: number;
  incidentNumber: number;
  note: string;
  supervisorName: string;
  isResolved: boolean;
  dateCreated: string;
  dateModified?: string;
  authorId: string;
}

export interface QAIssueDetail extends QAIssue {
  primaryCareProvider?: string;
  ptLastName?: string;
}

// Standard select lists from original code
export const DISPOSITION_OPTIONS = [
  'Transported (Emergency)',
  'Transported (Non-Emergent)',
  'Patient Refusal',
  'Cancelled',
  'No Treatment Required',
  'No Patient Identified',
];

export const CMS_LEVEL_OPTIONS = [
  'Basic Life Support (BLS)',
  'Basic Life Support (BLS) - Emergency',
  'Advanced Life Support, Level 1 (ALS1)',
  'Advanced Life Support, Level 1 (ALS1) - Emergency',
  'Advanced Life Support, Level 2 (ALS2)',
  'Specialty Care Transport (SCT)',
  'Paramedic Intercept (PI)',
];

export const DESTINATION_TYPE_OPTIONS = [
  'Hospital (Emergency Room Bed)',
  'Hospital (Non-Emergency Room Bed)',
  'Nursing Home/Skilled Nursing Facility',
  'Psychiatric Hospital',
  'Medical Office/Clinic',
  'Residence',
  'Hospice',
  'Other',
];

export const PATIENT_POSITION_OPTIONS = [
  'Supine',
  'Prone',
  'Right Lateral Recumbent',
  'Left Lateral Recumbent',
  "Fowler's",
  "Semi-Fowler's",
  'Trendelenberg',
  'Sitting',
];

export const GENDER_OPTIONS = ['Male', 'Female', 'Other'];

export const RESP_EFFORT_OPTIONS = [
  'Normal',
  'Apnea',
  'Dyspnea',
  'Hypoventilation',
  'Hyperventilation',
  'Tachypnea',
  'Kussmaul',
  'Cheyne-Stokes',
  'Biot',
  'Apneustic',
];

export const RHYTHM_OPTIONS = [
  'Normal',
  'Tachycardia',
  'Bradycardia',
  'Atrial Fibrillation',
  'Atrial Flutter',
  'Ventricular Fibrillation',
  'Ventricular Flutter',
  'Extrasystole',
  'Asystole',
];

export const BP_METHOD_OPTIONS = ['Manual-Auscultated', 'Automated-Cuff', 'Palpated'];

export const HR_TYPE_OPTIONS = [
  'Pulse-Oximeter',
  'Palpated',
  '3-Lead ECG',
  '5-Lead ECG',
  '12-Lead ECG',
];

export const GCS_VERBAL_OPTIONS = [
  { text: 'Oriented - 5', value: '5' },
  { text: 'Confused - 4', value: '4' },
  { text: 'Inappropriate Words - 3', value: '3' },
  { text: 'Incomprehensible Sounds - 2', value: '2' },
  { text: 'No Verbal Response - 1', value: '1' },
];

export const GCS_MOTOR_OPTIONS = [
  { text: 'Obeys Commands - 6', value: '6' },
  { text: 'Localizes Pain - 5', value: '5' },
  { text: 'Withdraws From Pain - 4', value: '4' },
  { text: 'Flexion Response to Pain - 3', value: '3' },
  { text: 'Extension Response to Pain - 2', value: '2' },
  { text: 'No Motor Response - 1', value: '1' },
];

export const GCS_EYES_OPTIONS = [
  { text: 'Eyes Open Spontaneously - 4', value: '4' },
  { text: 'Eye Opening to Verbal Command - 3', value: '3' },
  { text: 'Eye Opening to Pain - 2', value: '2' },
  { text: 'No Response - 1', value: '1' },
];
