import React from 'react';
import { FileText, AlertTriangle, PlusCircle, CheckCircle2, Clock } from 'lucide-react';
import { PCRStorageService } from '../services/storage';

interface HomeViewProps {
  onNavigate: (tab: string, id?: number) => void;
}

export const HomeView: React.FC<HomeViewProps> = ({ onNavigate }) => {
  const pcrs = PCRStorageService.getPCRs();
  const qaIssues = PCRStorageService.getQAIssues();
  const openIssues = qaIssues.filter((q) => !q.isResolved).length;

  return (
    <div className="space-y-8">
      {/* Jumbotron matching original CSS & background */}
      <div
        className="relative rounded-xl overflow-hidden shadow-lg border border-slate-300 min-h-[360px] flex items-center bg-cover bg-center"
        style={{
          backgroundImage: `linear-gradient(rgba(0,0,0,0.5), rgba(0,0,0,0.6)), url('/Images/ambo2.jpg')`,
          backgroundColor: '#1e293b',
        }}
      >
        <div className="relative z-10 p-6 sm:p-12 max-w-4xl text-white space-y-5">
          <div className="inline-block bg-black/60 backdrop-blur-xs px-4 py-2 rounded-lg border border-white/20">
            <h1 className="text-3xl sm:text-5xl font-extrabold tracking-tight text-white flex items-center gap-3">
              <img
                src="/Images/StarOfLife.png"
                alt="Star of Life"
                className="w-10 h-10 object-contain inline-block drop-shadow"
                onError={(e) => {
                  (e.target as HTMLElement).style.display = 'none';
                }}
              />
              AmbulancePCR
            </h1>
          </div>

          <p className="text-lg sm:text-xl text-neutral-100 bg-black/60 backdrop-blur-xs p-4 rounded-lg border border-white/20 leading-relaxed font-light">
            For use of EMS professionals to document patient demographics/medical history, narratives,
            times, addresses, and any other pertinent information from an emergency call, or non-emergent
            transport.
          </p>

          <div className="pt-2 flex flex-wrap items-center gap-4">
            <button
              onClick={() => onNavigate('pcr-create')}
              className="px-6 py-3 bg-blue-600 hover:bg-blue-700 text-white font-semibold text-lg rounded shadow hover:shadow-md transition-all flex items-center gap-2 cursor-pointer"
            >
              <PlusCircle className="w-5 h-5" />
              Create a PCR &raquo;
            </button>
            <button
              onClick={() => onNavigate('pcr-list')}
              className="px-6 py-3 bg-neutral-800/80 hover:bg-neutral-800 text-white font-semibold text-base rounded border border-white/30 backdrop-blur-xs transition-colors cursor-pointer"
            >
              View Active Reports ({pcrs.length})
            </button>
          </div>
        </div>
      </div>

      {/* Feature summary cards */}
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <div className="bg-white p-6 rounded-lg border border-slate-300 shadow-sm hover:shadow transition-shadow">
          <div className="flex items-center justify-between pb-3 border-b border-slate-200">
            <h2 className="text-lg font-bold text-slate-800 flex items-center gap-2">
              <FileText className="w-5 h-5 text-blue-600" />
              Patient Care Reports
            </h2>
            <span className="text-2xl font-black text-blue-600">{pcrs.length}</span>
          </div>
          <p className="mt-3 text-sm text-slate-600">
            Complete electronic PCR management including CMS billing level, vitals times, mileage, and clinical narratives.
          </p>
          <div className="mt-4 pt-3 border-t border-slate-100 flex justify-between items-center text-sm">
            <button
              onClick={() => onNavigate('pcr-list')}
              className="text-blue-700 hover:text-blue-900 font-semibold cursor-pointer"
            >
              Browse Reports &rarr;
            </button>
            <button
              onClick={() => onNavigate('pcr-create')}
              className="text-emerald-700 hover:text-emerald-900 font-semibold cursor-pointer"
            >
              + New Report
            </button>
          </div>
        </div>

        <div className="bg-white p-6 rounded-lg border border-slate-300 shadow-sm hover:shadow transition-shadow">
          <div className="flex items-center justify-between pb-3 border-b border-slate-200">
            <h2 className="text-lg font-bold text-slate-800 flex items-center gap-2">
              <AlertTriangle className="w-5 h-5 text-amber-600" />
              Quality Assurance (QA)
            </h2>
            <span className={`text-2xl font-black ${openIssues > 0 ? 'text-amber-600' : 'text-emerald-600'}`}>
              {openIssues} Open
            </span>
          </div>
          <p className="mt-3 text-sm text-slate-600">
            Supervisor quality review and auditing module. Track documentation discrepancies and resolution status.
          </p>
          <div className="mt-4 pt-3 border-t border-slate-100 flex justify-between items-center text-sm">
            <button
              onClick={() => onNavigate('qa-list')}
              className="text-amber-700 hover:text-amber-900 font-semibold cursor-pointer"
            >
              Review QA Issues &rarr;
            </button>
            <button
              onClick={() => onNavigate('qa-create')}
              className="text-blue-700 hover:text-blue-900 font-semibold cursor-pointer"
            >
              + Log QA Issue
            </button>
          </div>
        </div>

        <div className="bg-white p-6 rounded-lg border border-slate-300 shadow-sm hover:shadow transition-shadow">
          <div className="flex items-center justify-between pb-3 border-b border-slate-200">
            <h2 className="text-lg font-bold text-slate-800 flex items-center gap-2">
              <Clock className="w-5 h-5 text-indigo-600" />
              Shift Overview
            </h2>
            <span className="text-xs font-semibold px-2 py-1 rounded bg-blue-100 text-blue-800">
              Unit #104
            </span>
          </div>
          <div className="mt-3 space-y-2 text-sm text-slate-600">
            <div className="flex items-center justify-between">
              <span>Primary Provider:</span>
              <strong className="text-slate-800">Kevin Blanchard</strong>
            </div>
            <div className="flex items-center justify-between">
              <span>All QA Reviews:</span>
              <span className="font-semibold text-slate-800">{qaIssues.length} total logged</span>
            </div>
            <div className="flex items-center justify-between">
              <span>System Compliance:</span>
              <span className="font-semibold text-emerald-700 flex items-center gap-1">
                <CheckCircle2 className="w-4 h-4" /> 100% HIPAA Staged
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
