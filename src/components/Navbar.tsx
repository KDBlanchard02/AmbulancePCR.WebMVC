import React from 'react';
import { RotateCcw } from 'lucide-react';

interface NavbarProps {
  currentTab: string;
  onNavigate: (tab: string, id?: number) => void;
  currentUser: string;
  onResetData: () => void;
}

export const Navbar: React.FC<NavbarProps> = ({ currentTab, onNavigate, currentUser, onResetData }) => {
  const [mobileMenuOpen, setMobileMenuOpen] = React.useState(false);

  return (
    <nav className="bg-black text-white sticky top-0 z-50 shadow-md border-b border-neutral-800">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-14">
          {/* Brand & Star of Life */}
          <div className="flex items-center space-x-3">
            <button
              onClick={() => onNavigate('home')}
              className="flex items-center space-x-2.5 hover:opacity-90 transition-opacity focus:outline-none"
            >
              <img
                src="/Images/StarOfLife.png"
                alt="Star of Life"
                className="h-9 w-9 object-contain"
                onError={(e) => {
                  // Fallback if image fails to load
                  (e.target as HTMLElement).style.display = 'none';
                }}
              />
              <span className="font-bold text-xl tracking-tight text-white">AmbulancePCR</span>
            </button>

            {/* Desktop Navigation */}
            <div className="hidden md:flex items-center space-x-1 pl-4">
              <button
                onClick={() => onNavigate('pcr-list')}
                className={`px-3 py-1.5 rounded text-sm font-medium transition-colors ${
                  currentTab.startsWith('pcr') ? 'bg-neutral-800 text-white underline underline-offset-4 decoration-sky-400' : 'text-neutral-300 hover:text-white hover:bg-neutral-900'
                }`}
              >
                PCR
              </button>
              <button
                onClick={() => onNavigate('qa-list')}
                className={`px-3 py-1.5 rounded text-sm font-medium transition-colors ${
                  currentTab.startsWith('qa') ? 'bg-neutral-800 text-white underline underline-offset-4 decoration-sky-400' : 'text-neutral-300 hover:text-white hover:bg-neutral-900'
                }`}
              >
                Issues
              </button>
            </div>
          </div>

          {/* Right partial / User Identity */}
          <div className="hidden md:flex items-center space-x-4 text-sm">
            <button
              onClick={onResetData}
              title="Reset Sample Records"
              className="text-neutral-400 hover:text-neutral-200 text-xs flex items-center gap-1 px-2 py-1 rounded border border-neutral-700 bg-neutral-900 transition-colors"
            >
              <RotateCcw className="w-3 h-3" />
              Reset Demo Data
            </button>
            <div className="text-neutral-300 flex items-center space-x-2">
              <span>Hello <strong className="text-white">{currentUser}</strong>!</span>
              <span className="text-neutral-600">|</span>
              <span className="text-xs px-2 py-0.5 rounded bg-emerald-950 text-emerald-300 border border-emerald-800">
                Online (Shift Active)
              </span>
            </div>
          </div>

          {/* Mobile hamburger */}
          <div className="flex md:hidden items-center space-x-2">
            <button
              onClick={() => setMobileMenuOpen(!mobileMenuOpen)}
              className="p-2 rounded text-neutral-400 hover:text-white hover:bg-neutral-800 focus:outline-none"
            >
              <svg className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                {mobileMenuOpen ? (
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12" />
                ) : (
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h16M4 18h16" />
                )}
              </svg>
            </button>
          </div>
        </div>
      </div>

      {/* Mobile menu dropdown */}
      {mobileMenuOpen && (
        <div className="md:hidden px-4 pt-2 pb-4 space-y-2 bg-neutral-900 border-b border-neutral-800">
          <button
            onClick={() => {
              onNavigate('pcr-list');
              setMobileMenuOpen(false);
            }}
            className="block w-full text-left px-3 py-2 rounded text-base font-medium text-white hover:bg-neutral-800"
          >
            PCR
          </button>
          <button
            onClick={() => {
              onNavigate('qa-list');
              setMobileMenuOpen(false);
            }}
            className="block w-full text-left px-3 py-2 rounded text-base font-medium text-white hover:bg-neutral-800"
          >
            Issues
          </button>
          <div className="pt-2 border-t border-neutral-800 flex justify-between items-center text-xs text-neutral-400">
            <span>Hello <strong>{currentUser}</strong>!</span>
            <button
              onClick={() => {
                onResetData();
                setMobileMenuOpen(false);
              }}
              className="text-sky-400 hover:underline"
            >
              Reset Demo Data
            </button>
          </div>
        </div>
      )}
    </nav>
  );
};
