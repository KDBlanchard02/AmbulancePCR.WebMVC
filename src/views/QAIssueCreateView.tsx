import React, { useState } from 'react';
import { ArrowLeft, Save, AlertCircle } from 'lucide-react';
import { PCRStorageService } from '../services/storage';

interface QAIssueCreateViewProps {
  onNavigate: (tab: string, id?: number) => void;
  onShowMessage: (msg: string) => void;
}

export const QAIssueCreateView: React.FC<QAIssueCreateViewProps> = ({
  onNavigate,
  onShowMessage,
}) => {
  const pcrs = PCRStorageService.getPCRs();
  const [incidentNumber, setIncidentNumber] = useState<string>(
    pcrs.length > 0 ? pcrs[0].incidentNumber.toString() : ''
  );
  const [note, setNote] = useState('');
  const [supervisorName, setSupervisorName] = useState('Captain T. Henderson');
  const [error, setError] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    if (!incidentNumber) {
      setError('Incident Number is required.');
      return;
    }
    if (!note.trim()) {
      setError('QA Note details are required.');
      return;
    }
    if (!supervisorName.trim()) {
      setError('Supervisor Name is required.');
      return;
    }

    try {
      PCRStorageService.createQAIssue({
        incidentNumber: Number(incidentNumber),
        note,
        supervisorName,
      });
      onShowMessage('Q/A Issue was created.');
      onNavigate('qa-list');
    } catch {
      setError('Q/A Issue could not be created. Missing required values.');
    }
  };

  return (
    <div className="max-w-3xl mx-auto space-y-6">
      <div className="flex items-center justify-between pb-3 border-b border-slate-300">
        <div className="flex items-center space-x-3">
          <button
            onClick={() => onNavigate('qa-list')}
            className="p-2 rounded-full hover:bg-slate-200 text-slate-700 transition cursor-pointer"
          >
            <ArrowLeft className="w-5 h-5" />
          </button>
          <h2 className="text-2xl sm:text-3xl font-bold text-slate-900">Create QA Issue</h2>
        </div>
        <button
          onClick={() => onNavigate('qa-list')}
          className="text-sm font-semibold text-blue-700 hover:underline cursor-pointer"
        >
          Back to List
        </button>
      </div>

      {error && (
        <div className="p-3 bg-red-50 border border-red-300 rounded text-red-700 text-sm flex items-center gap-2">
          <AlertCircle className="w-5 h-5 text-red-600 shrink-0" />
          <span>{error}</span>
        </div>
      )}

      <form onSubmit={handleSubmit} className="bg-white p-6 rounded-lg border border-slate-300 shadow-sm space-y-5">
        <div className="border-b pb-2">
          <h4 className="text-sm font-semibold text-slate-500 uppercase tracking-wider">
            QAIssueCreate
          </h4>
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
            Incident # <span className="text-red-500">*</span>
          </label>
          {pcrs.length > 0 ? (
            <div className="space-y-1">
              <select
                value={incidentNumber}
                onChange={(e) => setIncidentNumber(e.target.value)}
                className="w-full p-2.5 border border-slate-300 rounded text-sm bg-white focus:ring-2 focus:ring-blue-500 focus:outline-none"
              >
                {pcrs.map((p) => (
                  <option key={p.incidentNumber} value={p.incidentNumber}>
                    Incident #{p.incidentNumber} - {p.primaryCareProvider} (Pt: {p.ptLastName})
                  </option>
                ))}
              </select>
              <p className="text-xs text-slate-500">Or type any incident number below:</p>
              <input
                type="number"
                value={incidentNumber}
                onChange={(e) => setIncidentNumber(e.target.value)}
                required
                className="w-full p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
              />
            </div>
          ) : (
            <input
              type="number"
              value={incidentNumber}
              onChange={(e) => setIncidentNumber(e.target.value)}
              placeholder="e.g. 20241101"
              required
              className="w-full p-2.5 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
            />
          )}
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
            Note / Audit Finding <span className="text-red-500">*</span>
          </label>
          <textarea
            rows={4}
            value={note}
            onChange={(e) => setNote(e.target.value)}
            placeholder="Describe the clinical documentation issue, missing signatures, telemetry discrepancies, or follow-up required..."
            required
            className="w-full p-3 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
            Supervisor Name <span className="text-red-500">*</span>
          </label>
          <input
            type="text"
            value={supervisorName}
            onChange={(e) => setSupervisorName(e.target.value)}
            required
            placeholder="e.g. Captain T. Henderson"
            className="w-full sm:w-1/2 p-2 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div className="pt-4 border-t border-slate-200 flex items-center justify-between">
          <button
            type="button"
            onClick={() => onNavigate('qa-list')}
            className="text-sm text-slate-600 hover:underline cursor-pointer"
          >
            Back to List
          </button>
          <button
            type="submit"
            className="px-6 py-2 bg-blue-600 hover:bg-blue-700 text-white font-semibold text-sm rounded shadow flex items-center gap-2 cursor-pointer"
          >
            <Save className="w-4 h-4" />
            Create
          </button>
        </div>
      </form>
    </div>
  );
};
