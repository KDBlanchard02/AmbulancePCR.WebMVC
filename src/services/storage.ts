import { PCRRecord, QAIssue, QAIssueDetail } from '../types/pcr';

const PCR_STORAGE_KEY = 'ambulance_pcr_records_v1';
const QA_STORAGE_KEY = 'ambulance_pcr_qa_issues_v1';

const SEED_PCR_RECORDS: PCRRecord[] = [
  {
    patientCareReportId: 1,
    authorId: 'e4b3c2a1-0000-0000-0000-000000000001',
    dateCreated: '2024-11-16T14:32:00Z',
    dateModified: '2024-11-16T15:10:00Z',
    incidentNumber: 20241101,
    disposition: 'Transported (Emergency)',
    sceneAddress: '742 Evergreen Terrace, Springfield',
    cmsLevel: 'Advanced Life Support, Level 1 (ALS1) - Emergency',
    vehicleNumber: 104,
    incidentDate: '2024-11-16',
    unitNotified: '14:15',
    enRoute: '14:17',
    onScene: '14:24',
    transporting: '14:40',
    destination: '14:55',
    inService: '15:20',
    primaryCareProvider: 'Kevin Blanchard, Paramedic',
    ambulanceDriver: 'Marcus Vance, EMT-B',
    loadMileage: 8.4,
    destinationAddress: 'Springfield Memorial Hospital, 100 Main St',
    reason: 'Substernal chest pain radiating to left arm',
    type: 'Hospital (Emergency Room Bed)',
    ptPosition: 'Semi-Fowler\'s',
    primarySymptom: 'Chest Pain / Angina',
    primaryImpression: 'Acute Coronary Syndrome (ACS)',
    secondaryImpression: 'Hypertensive Emergency',
    alcDrugUse: 'None suspected',
    pcrNarrative: 'Dispatched to 742 Evergreen Terrace for a 64 y/o male complaining of sudden onset retrosternal chest tightness (8/10 on pain scale) radiating down left arm with diaphoresis. Patient found sitting in armchair, pale and anxious. 12-lead ECG obtained showing ST elevation in leads II, III, aVF. IV 18G established in right AC. Aspirin 324mg PO given. Nitroglycerin 0.4mg SL administered with moderate pain reduction. Transport initiated emergent to Springfield Memorial Cath Lab. Vitals monitored continuously throughout transport. Care transferred without incident to Dr. Henderson.',
    reportingCrewMember: 'Kevin Blanchard, Paramedic',
    ptFirstName: 'John',
    ptLastName: 'Doe',
    ptAge: 64,
    ptDateOfBirth: '1960-04-12',
    ptGender: 'Male',
    ptWeight: 88,
    patientAddress: '742 Evergreen Terrace, Springfield',
    ptPhoneNumber: '555-019-8321',
    ptSSN: '***-**-4589',
    ptHistory: 'Hypertension, Hyperlipidemia, type 2 diabetes mellitus',
    ptAdvanceDirectives: 'Full Code',
    ptAllergiesMeds: 'Penicillin (rash)',
    ptAllergiesOther: 'None reported',
    ptMedications: 'Lisinopril 20mg, Atorvastatin 40mg, Metformin 500mg',
    systolicBloodPressure: 158,
    diastolicBloodPressure: 96,
    heartRate: 88,
    respiratoryRate: 20,
    respEffort: 'Dyspnea',
    rhythm: 'Normal',
    bpMethod: 'Manual-Auscultated',
    hrType: '12-Lead ECG',
    oximetry: 97,
    gcsVerbal: '5',
    gcsMotor: '6',
    gcsEyes: '4',
    bloodGlucose: 132,
    temperature: 98.4,
    vitalSignsTime: '14:28',
  },
  {
    patientCareReportId: 2,
    authorId: 'e4b3c2a1-0000-0000-0000-000000000001',
    dateCreated: '2024-11-17T09:15:00Z',
    dateModified: '2024-11-17T09:45:00Z',
    incidentNumber: 20241102,
    disposition: 'Transported (Non-Emergent)',
    sceneAddress: '12 Oak Ridge Blvd, Springfield',
    cmsLevel: 'Basic Life Support (BLS)',
    vehicleNumber: 102,
    incidentDate: '2024-11-17',
    unitNotified: '08:45',
    enRoute: '08:48',
    onScene: '08:58',
    transporting: '09:18',
    destination: '09:35',
    inService: '10:00',
    primaryCareProvider: 'Sarah Jenkins, EMT-AEMT',
    ambulanceDriver: 'Kevin Blanchard, Paramedic',
    loadMileage: 5.2,
    destinationAddress: 'Mercy Medical Center, 450 Health Way',
    reason: 'Mechanical ground-level fall with right hip pain',
    type: 'Hospital (Emergency Room Bed)',
    ptPosition: 'Supine',
    primarySymptom: 'Right Hip Pain / Inability to bear weight',
    primaryImpression: 'Possible Right Femoral Neck Fracture',
    secondaryImpression: 'Contusion Right Trochanteric',
    alcDrugUse: 'Negative',
    pcrNarrative: 'Dispatched for 78 y/o female who tripped on rug at residence. Patient denied loss of consciousness, head injury, or neck pain. Complained of moderate right hip pain upon palpation and movement. Right leg slightly shortened and externally rotated. Splinted and immobilized on scoop stretcher. Gentle movement into ambulance. Vital signs stable throughout transport. Arrived at Mercy Medical ER, transferred onto bed 4 with report given to RN Carlson.',
    reportingCrewMember: 'Sarah Jenkins, EMT-AEMT',
    ptFirstName: 'Eleanor',
    ptLastName: 'Rigby',
    ptAge: 78,
    ptDateOfBirth: '1946-08-23',
    ptGender: 'Female',
    ptWeight: 62,
    patientAddress: '12 Oak Ridge Blvd, Springfield',
    ptPhoneNumber: '555-014-9912',
    ptSSN: '***-**-7714',
    ptHistory: 'Osteoporosis, Mild cognitive impairment',
    ptAdvanceDirectives: 'DNR on file',
    ptAllergiesMeds: 'Sulfa antibiotics',
    ptAllergiesOther: 'Adhesive tape',
    ptMedications: 'Alendronate, Calcium with Vit D, Donepezil',
    systolicBloodPressure: 130,
    diastolicBloodPressure: 82,
    heartRate: 76,
    respiratoryRate: 16,
    respEffort: 'Normal',
    rhythm: 'Normal',
    bpMethod: 'Automated-Cuff',
    hrType: 'Pulse-Oximeter',
    oximetry: 98,
    gcsVerbal: '5',
    gcsMotor: '6',
    gcsEyes: '4',
    bloodGlucose: 104,
    temperature: 98.6,
    vitalSignsTime: '09:05',
  },
];

const SEED_QA_ISSUES: QAIssue[] = [
  {
    issueId: 1,
    incidentNumber: 20241101,
    note: 'Please verify if repeat 12-lead was captured en route to cath lab and ensure second BP cycle is recorded.',
    supervisorName: 'Captain T. Henderson',
    isResolved: false,
    dateCreated: '2024-11-16T16:20:00Z',
    dateModified: '2024-11-16T16:20:00Z',
    authorId: 'e4b3c2a1-0000-0000-0000-000000000001',
  },
  {
    issueId: 2,
    incidentNumber: 20241102,
    note: 'Load mileage verified against dispatch CAD record. All good.',
    supervisorName: 'Quality Director A. Miller',
    isResolved: true,
    dateCreated: '2024-11-17T11:00:00Z',
    dateModified: '2024-11-17T12:30:00Z',
    authorId: 'e4b3c2a1-0000-0000-0000-000000000001',
  },
];

export const PCRStorageService = {
  getPCRs(): PCRRecord[] {
    const raw = localStorage.getItem(PCR_STORAGE_KEY);
    if (!raw) {
      localStorage.setItem(PCR_STORAGE_KEY, JSON.stringify(SEED_PCR_RECORDS));
      return SEED_PCR_RECORDS;
    }
    try {
      return JSON.parse(raw);
    } catch {
      return SEED_PCR_RECORDS;
    }
  },

  getPCRById(id: number): PCRRecord | undefined {
    const records = this.getPCRs();
    return records.find((r) => r.patientCareReportId === id);
  },

  getPCRByIncidentNumber(incidentNumber: number): PCRRecord | undefined {
    const records = this.getPCRs();
    return records.find((r) => r.incidentNumber === incidentNumber);
  },

  createPCR(record: Omit<PCRRecord, 'patientCareReportId' | 'dateCreated' | 'dateModified' | 'authorId'>): PCRRecord {
    const records = this.getPCRs();
    const nextId = records.length > 0 ? Math.max(...records.map((r) => r.patientCareReportId)) + 1 : 1;
    const now = new Date().toISOString();
    const newRecord: PCRRecord = {
      ...record,
      patientCareReportId: nextId,
      authorId: 'e4b3c2a1-0000-0000-0000-000000000001',
      dateCreated: now,
      dateModified: now,
    };
    records.unshift(newRecord);
    localStorage.setItem(PCR_STORAGE_KEY, JSON.stringify(records));
    return newRecord;
  },

  updatePCR(id: number, updates: Partial<PCRRecord>): boolean {
    const records = this.getPCRs();
    const index = records.findIndex((r) => r.patientCareReportId === id);
    if (index === -1) return false;
    records[index] = {
      ...records[index],
      ...updates,
      dateModified: new Date().toISOString(),
    };
    localStorage.setItem(PCR_STORAGE_KEY, JSON.stringify(records));
    return true;
  },

  deletePCR(id: number): boolean {
    const records = this.getPCRs();
    const filtered = records.filter((r) => r.patientCareReportId !== id);
    if (filtered.length === records.length) return false;
    localStorage.setItem(PCR_STORAGE_KEY, JSON.stringify(filtered));
    return true;
  },

  // QA Issues CRUD
  getQAIssues(): QAIssue[] {
    const raw = localStorage.getItem(QA_STORAGE_KEY);
    if (!raw) {
      localStorage.setItem(QA_STORAGE_KEY, JSON.stringify(SEED_QA_ISSUES));
      return SEED_QA_ISSUES;
    }
    try {
      return JSON.parse(raw);
    } catch {
      return SEED_QA_ISSUES;
    }
  },

  getQAIssueById(id: number): QAIssueDetail | undefined {
    const issues = this.getQAIssues();
    const issue = issues.find((i) => i.issueId === id);
    if (!issue) return undefined;
    const pcr = this.getPCRByIncidentNumber(issue.incidentNumber);
    return {
      ...issue,
      primaryCareProvider: pcr?.primaryCareProvider ?? 'Not Assigned',
      ptLastName: pcr?.ptLastName ?? 'Unknown',
    };
  },

  createQAIssue(data: { incidentNumber: number; note: string; supervisorName: string }): QAIssue {
    const issues = this.getQAIssues();
    const nextId = issues.length > 0 ? Math.max(...issues.map((i) => i.issueId)) + 1 : 1;
    const now = new Date().toISOString();
    const newIssue: QAIssue = {
      issueId: nextId,
      incidentNumber: Number(data.incidentNumber),
      note: data.note,
      supervisorName: data.supervisorName,
      isResolved: false,
      dateCreated: now,
      dateModified: now,
      authorId: 'e4b3c2a1-0000-0000-0000-000000000001',
    };
    issues.unshift(newIssue);
    localStorage.setItem(QA_STORAGE_KEY, JSON.stringify(issues));
    return newIssue;
  },

  updateQAIssue(id: number, data: { note: string; isResolved: boolean }): boolean {
    const issues = this.getQAIssues();
    const index = issues.findIndex((i) => i.issueId === id);
    if (index === -1) return false;
    issues[index] = {
      ...issues[index],
      note: data.note,
      isResolved: data.isResolved,
      dateModified: new Date().toISOString(),
    };
    localStorage.setItem(QA_STORAGE_KEY, JSON.stringify(issues));
    return true;
  },

  deleteQAIssue(id: number): boolean {
    const issues = this.getQAIssues();
    const filtered = issues.filter((i) => i.issueId !== id);
    if (filtered.length === issues.length) return false;
    localStorage.setItem(QA_STORAGE_KEY, JSON.stringify(filtered));
    return true;
  },

  resetDefaults() {
    localStorage.setItem(PCR_STORAGE_KEY, JSON.stringify(SEED_PCR_RECORDS));
    localStorage.setItem(QA_STORAGE_KEY, JSON.stringify(SEED_QA_ISSUES));
  },
};
