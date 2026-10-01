import React from 'react';
import { ArrowLeft, Trash2, AlertOctagon } from 'lucide-react';
import { PCRStorageService } from '../services/storage';

interface PCRDeleteViewProps {
  recordId: number;
  onNavigate: (tab: string, id?: number) => void;
  onShowMessage: (msg: string) => void;
}

export const PCRDeleteView: React.FC<PCRDeleteViewProps> = ({
  recordId,
  onNavigate,
  onShowMessage,
}) => {
  const pcr = PCRStorageService.getPCRById(recordId);

  if (!pcr) {
    return (
      <div className="max-w-xl mx-auto p-8 text-center bg-white rounded border border-slate-300">
        <h2 className="text-xl font-bold text-red-600">Patient Care Report Not Found</h2>
        <button
          onClick={() => onNavigate('pcr-list')}
          className="mt-4 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
        >
          Back to List
        </button>
      </div>
    );
  }

  const handleDelete = () => {
    const success = PCRStorageService.deletePCR(recordId);
    if (success) {
      onShowMessage('Your PCR was deleted.');
      onNavigate('pcr-list');
    }
  };

  return (
    <div className="max-w-2xl mx-auto space-y-6">
      <div className="flex items-center space-x-3 pb-3 border-b border-slate-300">
        <button
          onClick={() => onNavigate('pcr-list')}
          className="p-2 rounded-full hover:bg-slate-200 text-slate-700 transition cursor-pointer"
        >
          <ArrowLeft className="w-5 h-5" />
        </button>
        <h2 className="text-2xl font-bold text-slate-900">Delete Patient Care Report</h2>
      </div>

      <div className="bg-red-50 border-2 border-red-300 p-6 rounded-lg text-red-900 space-y-4">
        <div className="flex items-center gap-3">
          <AlertOctagon className="w-8 h-8 text-red-600 shrink-0" />
          <div>
            <h3 className="text-lg font-bold text-red-800">
              Are you sure you want to delete this PCR?
            </h3>
            <p className="text-sm text-red-700">
              This action cannot be undone. All linked patient records and vitals will be permanently removed.
            </p>
          </div>
        </div>

        <div className="bg-white p-4 rounded border border-red-200 text-sm space-y-2 text-slate-800">
          <div className="flex justify-between border-b pb-1">
            <span className="font-semibold text-slate-600">Incident Number:</span>
            <span className="font-mono font-bold">#{pcr.incidentNumber}</span>
          </div>
          <div className="flex justify-between border-b pb-1">
            <span className="font-semibold text-slate-600">Primary Care Provider:</span>
            <span>{pcr.primaryCareProvider}</span>
          </div>
          <div className="flex justify-between border-b pb-1">
            <span className="font-semibold text-slate-600">Patient Name:</span>
            <span>{pcr.ptLastName}, {pcr.ptFirstName}</span>
          </div>
          <div className="flex justify-between border-b pb-1">
            <span className="font-semibold text-slate-600">Incident Date:</span>
            <span>{pcr.incidentDate}</span>
          </div>
          <div className="flex justify-between">
            <span className="font-semibold text-slate-600">Scene Address:</span>
            <span>{pcr.sceneAddress}</span>
          </div>
        </div>

        <div className="flex items-center justify-between pt-2">
          <button
            onClick={() => onNavigate('pcr-list')}
            className="px-4 py-2 border border-slate-300 bg-white hover:bg-slate-50 text-slate-700 rounded font-medium text-sm cursor-pointer"
          >
            Cancel & Return
          </button>
          <button
            onClick={handleDelete}
            className="px-5 py-2 bg-red-600 hover:bg-red-700 text-white rounded font-bold text-sm flex items-center gap-2 shadow hover:shadow-md transition cursor-pointer"
          >
            <Trash2 className="w-4 h-4" />
            Delete Report
          </button>
        </div>
      </div>
    </div>
  );
};
