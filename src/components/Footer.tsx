import React from 'react';

export const Footer: React.FC = () => {
  return (
    <footer className="mt-16 py-6 border-t border-slate-300 text-slate-600 text-sm">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex flex-col sm:flex-row justify-between items-center gap-2">
        <p>&copy; {new Date().getFullYear()} - AmbulancePCR - Kevin Blanchard</p>
        <p className="text-xs text-slate-500">
          Emergency Medical Services (EMS) Patient Care Reporting System
        </p>
      </div>
    </footer>
  );
};
