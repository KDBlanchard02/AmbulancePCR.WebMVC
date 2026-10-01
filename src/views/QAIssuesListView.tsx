import React, { useState } from 'react';
import { Plus, Eye, Edit3, Trash2, CheckCircle2, Clock, Search, AlertCircle } from 'lucide-react';
import { QAIssue } from '../types/pcr';

interface QAIssuesListViewProps {
  issues: QAIssue[];
  onNavigate: (tab: string, id?: number) => void;
}

export const QAIssuesListView: React.FC<QAIssuesListViewProps> = ({ issues, onNavigate }) => {
  const [searchTerm, setSearchTerm] = useState('');
  const [filterResolved, setFilterResolved] = useState<'all' | 'open' | 'resolved'>('all');

  const filteredIssues = issues.filter((issue) => {
    const matchesSearch =
      issue.incidentNumber.toString().includes(searchTerm) ||
      issue.supervisorName?.toLowerCase().includes(searchTerm.toLowerCase()) ||
      issue.note?.toLowerCase().includes(searchTerm.toLowerCase());

    if (!matchesSearch) return false;
    if (filterResolved === 'open') return !issue.isResolved;
    if (filterResolved === 'resolved') return issue.isResolved;
    return true;
  });

  return (
    <div className="space-y-6">
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-2 border-b border-slate-300">
        <div>
          <h2 className="text-2xl sm:text-3xl font-bold text-slate-900">Quality Assurance (QA) Issues</h2>
          <p className="text-sm text-slate-600 mt-1">
            Clinical documentation audits, supervisory reviews, and action items
          </p>
        </div>
        <div>
          <button
            onClick={() => onNavigate('qa-create')}
            className="px-5 py-2.5 bg-blue-600 hover:bg-blue-700 text-white font-semibold text-base rounded shadow hover:shadow-md transition flex items-center gap-2 cursor-pointer"
          >
            <Plus className="w-5 h-5" />
            Create &raquo;
          </button>
        </div>
      </div>

      {/* Filter and Search Bar */}
      <div className="flex flex-col sm:flex-row items-stretch sm:items-center gap-3 bg-white p-3 rounded border border-slate-300 shadow-xs">
        <div className="flex items-center gap-2 flex-1">
          <Search className="w-5 h-5 text-slate-400" />
          <input
            type="text"
            placeholder="Search by incident #, supervisor, notes..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="w-full text-sm outline-none text-slate-800 placeholder-slate-400"
          />
        </div>

        <div className="flex items-center gap-1 border-t sm:border-t-0 sm:border-l sm:pl-3 pt-2 sm:pt-0">
          <span className="text-xs text-slate-500 mr-1">Status:</span>
          <button
            onClick={() => setFilterResolved('all')}
            className={`px-2.5 py-1 text-xs rounded font-medium cursor-pointer ${
              filterResolved === 'all'
                ? 'bg-slate-800 text-white'
                : 'bg-slate-100 text-slate-700 hover:bg-slate-200'
            }`}
          >
            All ({issues.length})
          </button>
          <button
            onClick={() => setFilterResolved('open')}
            className={`px-2.5 py-1 text-xs rounded font-medium cursor-pointer ${
              filterResolved === 'open'
                ? 'bg-amber-600 text-white'
                : 'bg-amber-50 text-amber-800 hover:bg-amber-100'
            }`}
          >
            Open ({issues.filter((i) => !i.isResolved).length})
          </button>
          <button
            onClick={() => setFilterResolved('resolved')}
            className={`px-2.5 py-1 text-xs rounded font-medium cursor-pointer ${
              filterResolved === 'resolved'
                ? 'bg-emerald-600 text-white'
                : 'bg-emerald-50 text-emerald-800 hover:bg-emerald-100'
            }`}
          >
            Resolved ({issues.filter((i) => i.isResolved).length})
          </button>
        </div>
      </div>

      {/* Table matching the original bootstrap table with lightblue styling */}
      <div className="overflow-x-auto shadow-sm">
        <table className="w-full border-collapse border-4 border-slate-400 bg-sky-50 text-left text-sm">
          <thead>
            <tr className="bg-slate-800 text-white uppercase text-xs tracking-wider">
              <th className="p-3 border border-slate-400 font-semibold">Incident #</th>
              <th className="p-3 border border-slate-400 font-semibold">Is Resolved</th>
              <th className="p-3 border border-slate-400 font-semibold">Date Created</th>
              <th className="p-3 border border-slate-400 font-semibold">Supervisor Name</th>
              <th className="p-3 border border-slate-400 font-semibold text-center w-48">Actions</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-slate-300">
            {filteredIssues.length === 0 ? (
              <tr>
                <td colSpan={5} className="p-8 text-center text-slate-500 bg-white">
                  No Quality Assurance issues found.
                </td>
              </tr>
            ) : (
              filteredIssues.map((item) => (
                <tr key={item.issueId} className="hover:bg-sky-100/70 transition-colors">
                  <td className="p-3 border border-slate-300 font-mono font-bold text-slate-900">
                    #{item.incidentNumber}
                  </td>
                  <td className="p-3 border border-slate-300">
                    {item.isResolved ? (
                      <span className="inline-flex items-center gap-1 px-2.5 py-0.5 rounded-full text-xs font-semibold bg-emerald-100 text-emerald-800 border border-emerald-300">
                        <CheckCircle2 className="w-3.5 h-3.5" />
                        Resolved
                      </span>
                    ) : (
                      <span className="inline-flex items-center gap-1 px-2.5 py-0.5 rounded-full text-xs font-semibold bg-amber-100 text-amber-800 border border-amber-300">
                        <Clock className="w-3.5 h-3.5" />
                        Pending Review
                      </span>
                    )}
                  </td>
                  <td className="p-3 border border-slate-300 text-slate-700">
                    {item.dateCreated ? new Date(item.dateCreated).toLocaleDateString() : 'N/A'}
                  </td>
                  <td className="p-3 border border-slate-300 font-medium text-slate-900">
                    {item.supervisorName}
                  </td>
                  <td className="p-3 border border-slate-300 text-center">
                    <div className="pcr-table-action inline-flex shadow-xs">
                      <button
                        onClick={() => onNavigate('qa-edit', item.issueId)}
                        className="text-blue-700 hover:text-blue-900 font-medium hover:underline flex items-center gap-1 cursor-pointer"
                        title="Edit QA Issue"
                      >
                        <Edit3 className="w-3.5 h-3.5" />
                        Edit
                      </button>
                      <span className="text-slate-400">|</span>
                      <button
                        onClick={() => onNavigate('qa-detail', item.issueId)}
                        className="text-blue-700 hover:text-blue-900 font-medium hover:underline flex items-center gap-1 cursor-pointer"
                        title="View Details"
                      >
                        <Eye className="w-3.5 h-3.5" />
                        Details
                      </button>
                      <span className="text-slate-400">|</span>
                      <button
                        onClick={() => onNavigate('qa-delete', item.issueId)}
                        className="text-red-700 hover:text-red-900 font-medium hover:underline flex items-center gap-1 cursor-pointer"
                        title="Delete QA Issue"
                      >
                        <Trash2 className="w-3.5 h-3.5" />
                        Delete
                      </button>
                    </div>
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};
