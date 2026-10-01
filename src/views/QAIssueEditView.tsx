import React, { useState, useEffect } from 'react';
import { ArrowLeft, Save, AlertCircle } from 'lucide-react';
import { PCRStorageService } from '../services/storage';

interface QAIssueEditViewProps {
  issueId: number;
  onNavigate: (tab: string, id?: number) => void;
  onShowMessage: (msg: string) => void;
}

export const QAIssueEditView: React.FC<QAIssueEditViewProps> = ({
  issueId,
  onNavigate,
  onShowMessage,
}) => {
  const [note, setNote] = useState('');
  const [isResolved, setIsResolved] = useState(false);
  const [incidentNumber, setIncidentNumber] = useState<number | null>(null);
  const [error, setError] = useState('');

  useEffect(() => {
    const issue = PCRStorageService.getQAIssueById(issueId);
    if (issue) {
      setNote(issue.note);
      setIsResolved(issue.isResolved);
      setIncidentNumber(issue.incidentNumber);
    } else {
      setError(`QA Issue #${issueId} not found.`);
    }
  }, [issueId]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    if (!note.trim()) {
      setError('Note cannot be blank.');
      return;
    }

    const success = PCRStorageService.updateQAIssue(issueId, { note, isResolved });
    if (success) {
      onShowMessage('Issue has been updated.');
      onNavigate('qa-list');
    } else {
      setError('Issue could not be updated.');
    }
  };

  return (
    <div className="max-w-2xl mx-auto space-y-6">
      <div className="flex items-center justify-between pb-3 border-b border-slate-300">
        <div className="flex items-center space-x-3">
          <button
            onClick={() => onNavigate('qa-list')}
            className="p-2 rounded-full hover:bg-slate-200 text-slate-700 transition cursor-pointer"
          >
            <ArrowLeft className="w-5 h-5" />
          </button>
          <h2 className="text-2xl sm:text-3xl font-bold text-slate-900">
            Edit QA Issue #{issueId}
          </h2>
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
        <div className="border-b pb-2 flex justify-between items-center">
          <h4 className="text-sm font-semibold text-slate-500 uppercase tracking-wider">
            QAIssueEdit
          </h4>
          {incidentNumber && (
            <span className="text-xs font-mono font-semibold px-2 py-0.5 rounded bg-slate-100 text-slate-700">
              Linked to Incident #{incidentNumber}
            </span>
          )}
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-700 uppercase mb-1">
            Audit Note / Action Items <span className="text-red-500">*</span>
          </label>
          <textarea
            rows={5}
            value={note}
            onChange={(e) => setNote(e.target.value)}
            required
            className="w-full p-3 border border-slate-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
          />
        </div>

        <div className="p-4 bg-slate-50 border border-slate-200 rounded">
          <label className="flex items-center space-x-3 cursor-pointer">
            <input
              type="checkbox"
              checked={isResolved}
              onChange={(e) => setIsResolved(e.target.checked)}
              className="h-5 w-5 rounded border-slate-300 text-emerald-600 focus:ring-emerald-500"
            />
            <div>
              <span className="font-semibold text-slate-800 text-sm">
                Mark as Resolved
              </span>
              <p className="text-xs text-slate-500">
                Check this box once the crew member has corrected the clinical documentation or addressed findings.
              </p>
            </div>
          </label>
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
            Save
          </button>
        </div>
      </form>
    </div>
  );
};
