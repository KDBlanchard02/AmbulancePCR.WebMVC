import React from 'react';
import { ArrowLeft, Edit3, Trash2, CheckCircle2, Clock } from 'lucide-react';
import { PCRStorageService } from '../services/storage';

interface QAIssueDetailViewProps {
  issueId: number;
  onNavigate: (tab: string, id?: number) => void;
}

export const QAIssueDetailView: React.FC<QAIssueDetailViewProps> = ({ issueId, onNavigate }) => {
  const issue = PCRStorageService.getQAIssueById(issueId);

  if (!issue) {
    return (
      <div className="max-w-2xl mx-auto p-8 text-center bg-white rounded border border-slate-300">
        <h2 className="text-xl font-bold text-red-600">QA Issue Not Found</h2>
        <button
          onClick={() => onNavigate('qa-list')}
          className="mt-4 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
        >
          Back to List
        </button>
      </div>
    );
  }

  const fields = [
    { label: 'Incident #', value: `#${issue.incidentNumber}` },
    { label: 'Note', value: issue.note, isLong: true },
    { label: 'Primary Care Provider', value: issue.primaryCareProvider || 'Not Assigned' },
    { label: 'Pt Last Name', value: issue.ptLastName || 'Unknown' },
    {
      label: 'Is Resolved',
      value: issue.isResolved ? 'True (Resolved)' : 'False (Pending Review)',
      isBadge: true,
      resolved: issue.isResolved,
    },
    {
      label: 'Date Created',
      value: issue.dateCreated ? new Date(issue.dateCreated).toLocaleString() : 'N/A',
    },
    {
      label: 'Date Modified',
      value: issue.dateModified ? new Date(issue.dateModified).toLocaleString() : 'N/A',
    },
    { label: 'Supervisor Name', value: issue.supervisorName },
  ];

  return (
    <div className="max-w-3xl mx-auto space-y-6">
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-2 border-b border-slate-300">
        <div className="flex items-center space-x-3">
          <button
            onClick={() => onNavigate('qa-list')}
            className="p-2 rounded-full hover:bg-slate-200 text-slate-700 transition cursor-pointer"
            title="Back to List"
          >
            <ArrowLeft className="w-5 h-5" />
          </button>
          <div>
            <h2 className="text-2xl sm:text-3xl font-bold text-slate-900">
              Details - QA Issue #{issue.issueId}
            </h2>
            <p className="text-sm text-slate-500">Incident #{issue.incidentNumber}</p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          <button
            onClick={() => onNavigate('qa-edit', issue.issueId)}
            className="px-3 py-1.5 bg-blue-600 hover:bg-blue-700 text-white rounded text-sm font-semibold flex items-center gap-1.5 cursor-pointer"
          >
            <Edit3 className="w-4 h-4" />
            Edit
          </button>
          <button
            onClick={() => onNavigate('qa-delete', issue.issueId)}
            className="px-3 py-1.5 bg-red-600 hover:bg-red-700 text-white rounded text-sm font-semibold flex items-center gap-1.5 cursor-pointer"
          >
            <Trash2 className="w-4 h-4" />
            Delete
          </button>
        </div>
      </div>

      {/* Styled DL matching original AmbulancePCR */}
      <div className="border-4 border-slate-400 bg-white shadow-md rounded overflow-hidden">
        <dl className="grid grid-cols-1 sm:grid-cols-12 divide-y divide-slate-300 text-sm">
          {fields.map((f, idx) => (
            <React.Fragment key={idx}>
              <dt className="sm:col-span-4 bg-neutral-800 text-white sm:text-right px-4 py-3 font-semibold flex items-center sm:justify-end">
                {f.label}
              </dt>
              <dd className="sm:col-span-8 bg-white px-4 py-3 text-slate-900 flex items-center">
                {f.isBadge ? (
                  <span
                    className={`inline-flex items-center gap-1 px-2.5 py-0.5 rounded-full text-xs font-semibold ${
                      f.resolved
                        ? 'bg-emerald-100 text-emerald-800 border border-emerald-300'
                        : 'bg-amber-100 text-amber-800 border border-amber-300'
                    }`}
                  >
                    {f.resolved ? <CheckCircle2 className="w-3.5 h-3.5" /> : <Clock className="w-3.5 h-3.5" />}
                    {f.value}
                  </span>
                ) : f.isLong ? (
                  <p className="whitespace-pre-wrap leading-relaxed text-slate-800">{f.value}</p>
                ) : (
                  <span>{f.value}</span>
                )}
              </dd>
            </React.Fragment>
          ))}
        </dl>
      </div>

      <div className="pt-2 text-sm">
        <button
          onClick={() => onNavigate('qa-list')}
          className="text-blue-700 hover:underline font-semibold cursor-pointer"
        >
          | Back to List |
        </button>
      </div>
    </div>
  );
};
