import React, { useState } from 'react';
import { Search, Plus, Eye, Edit3, Trash2, Calendar, User, Hash } from 'lucide-react';
import { PCRRecord } from '../types/pcr';

interface PCRListViewProps {
  pcrs: PCRRecord[];
  onNavigate: (tab: string, id?: number) => void;
}

export const PCRListView: React.FC<PCRListViewProps> = ({ pcrs, onNavigate }) => {
  const [searchTerm, setSearchTerm] = useState('');

  const filteredPcrs = pcrs.filter((p) => {
    const term = searchTerm.toLowerCase();
    return (
      p.primaryCareProvider?.toLowerCase().includes(term) ||
      p.incidentNumber.toString().includes(term) ||
      p.incidentDate?.toLowerCase().includes(term) ||
      p.ptLastName?.toLowerCase().includes(term) ||
      p.sceneAddress?.toLowerCase().includes(term)
    );
  });

  return (
    <div className="space-y-6">
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-2 border-b border-slate-300">
        <div>
          <h2 className="text-2xl sm:text-3xl font-bold text-slate-900">Patient Care Reports</h2>
          <p className="text-sm text-slate-600 mt-1">
            Official run logs and pre-hospital documentation
          </p>
        </div>
        <div>
          <button
            onClick={() => onNavigate('pcr-create')}
            className="px-5 py-2.5 bg-blue-600 hover:bg-blue-700 text-white font-semibold text-base rounded shadow hover:shadow-md transition flex items-center gap-2 cursor-pointer"
          >
            <Plus className="w-5 h-5" />
            Create &raquo;
          </button>
        </div>
      </div>

      {/* Search Bar */}
      <div className="flex items-center gap-3 bg-white p-3 rounded border border-slate-300 shadow-xs">
        <Search className="w-5 h-5 text-slate-400" />
        <input
          type="text"
          placeholder="Filter by incident #, provider, patient last name, address..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="w-full text-sm outline-none text-slate-800 placeholder-slate-400"
        />
        {searchTerm && (
          <button
            onClick={() => setSearchTerm('')}
            className="text-xs text-slate-500 hover:text-slate-800 px-2 py-1 bg-slate-100 rounded"
          >
            Clear
          </button>
        )}
      </div>

      {/* Table matching the original bootstrap styled table with lightblue / inset border */}
      <div className="overflow-x-auto shadow-sm">
        <table className="w-full border-collapse border-4 border-slate-400 bg-sky-50 text-left text-sm">
          <thead>
            <tr className="bg-slate-800 text-white uppercase text-xs tracking-wider">
              <th className="p-3 border border-slate-400 font-semibold">
                <span className="flex items-center gap-1.5">
                  <User className="w-4 h-4 text-sky-400" />
                  Primary Care Provider
                </span>
              </th>
              <th className="p-3 border border-slate-400 font-semibold">
                <span className="flex items-center gap-1.5">
                  <Calendar className="w-4 h-4 text-sky-400" />
                  Incident Date
                </span>
              </th>
              <th className="p-3 border border-slate-400 font-semibold">
                <span className="flex items-center gap-1.5">
                  <Hash className="w-4 h-4 text-sky-400" />
                  Incident #
                </span>
              </th>
              <th className="p-3 border border-slate-400 font-semibold text-center w-48">
                Actions
              </th>
            </tr>
          </thead>
          <tbody className="divide-y divide-slate-300">
            {filteredPcrs.length === 0 ? (
              <tr>
                <td colSpan={4} className="p-8 text-center text-slate-500 bg-white">
                  No Patient Care Reports found matching your search.
                </td>
              </tr>
            ) : (
              filteredPcrs.map((item) => (
                <tr key={item.patientCareReportId} className="hover:bg-sky-100/70 transition-colors">
                  <td className="p-3 border border-slate-300 font-medium text-slate-900">
                    <div>{item.primaryCareProvider}</div>
                    <div className="text-xs text-slate-500 font-normal">
                      Patient: {item.ptLastName}, {item.ptFirstName}
                    </div>
                  </td>
                  <td className="p-3 border border-slate-300 text-slate-700">
                    {item.incidentDate || 'N/A'}
                  </td>
                  <td className="p-3 border border-slate-300 font-mono text-slate-900 font-semibold">
                    #{item.incidentNumber}
                  </td>
                  <td className="p-3 border border-slate-300 text-center">
                    <div className="pcr-table-action inline-flex shadow-xs">
                      <button
                        onClick={() => onNavigate('pcr-edit', item.patientCareReportId)}
                        className="text-blue-700 hover:text-blue-900 font-medium hover:underline flex items-center gap-1 cursor-pointer"
                        title="Edit PCR"
                      >
                        <Edit3 className="w-3.5 h-3.5" />
                        Edit
                      </button>
                      <span className="text-slate-400">|</span>
                      <button
                        onClick={() => onNavigate('pcr-detail', item.patientCareReportId)}
                        className="text-blue-700 hover:text-blue-900 font-medium hover:underline flex items-center gap-1 cursor-pointer"
                        title="View Details"
                      >
                        <Eye className="w-3.5 h-3.5" />
                        Details
                      </button>
                      <span className="text-slate-400">|</span>
                      <button
                        onClick={() => onNavigate('pcr-delete', item.patientCareReportId)}
                        className="text-red-700 hover:text-red-900 font-medium hover:underline flex items-center gap-1 cursor-pointer"
                        title="Delete PCR"
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
