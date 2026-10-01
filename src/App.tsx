import React, { useState, useEffect } from 'react';
import { Navbar } from './components/Navbar';
import { Footer } from './components/Footer';
import { HomeView } from './views/HomeView';
import { PCRListView } from './views/PCRListView';
import { PCRCreateEditView } from './views/PCRCreateEditView';
import { PCRDetailView } from './views/PCRDetailView';
import { PCRDeleteView } from './views/PCRDeleteView';
import { QAIssuesListView } from './views/QAIssuesListView';
import { QAIssueCreateView } from './views/QAIssueCreateView';
import { QAIssueEditView } from './views/QAIssueEditView';
import { QAIssueDetailView } from './views/QAIssueDetailView';
import { QAIssueDeleteView } from './views/QAIssueDeleteView';
import { PCRStorageService } from './services/storage';
import { PCRRecord, QAIssue } from './types/pcr';
import { CheckCircle2, X } from 'lucide-react';

export const App: React.FC = () => {
  const [currentTab, setCurrentTab] = useState<string>('home');
  const [selectedId, setSelectedId] = useState<number | undefined>(undefined);
  const [toastMessage, setToastMessage] = useState<string | null>(null);
  const [pcrs, setPcrs] = useState<PCRRecord[]>([]);
  const [issues, setIssues] = useState<QAIssue[]>([]);
  const currentUser = 'KevinBlanchard';

  // Load data from storage service
  const refreshData = () => {
    setPcrs(PCRStorageService.getPCRs());
    setIssues(PCRStorageService.getQAIssues());
  };

  useEffect(() => {
    refreshData();
  }, []);

  const handleNavigate = (tab: string, id?: number) => {
    setSelectedId(id);
    setCurrentTab(tab);
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };

  const handleShowMessage = (msg: string) => {
    setToastMessage(msg);
    refreshData();
    setTimeout(() => {
      setToastMessage(null);
    }, 4500);
  };

  const handleResetData = () => {
    if (window.confirm('Reset all demo Patient Care Reports and QA Issues to initial state?')) {
      PCRStorageService.resetDefaults();
      refreshData();
      handleShowMessage('Demo data restored to initial state.');
      handleNavigate('home');
    }
  };

  return (
    <div className="min-h-screen flex flex-col bg-[#f0ffff] text-slate-800">
      <Navbar
        currentTab={currentTab}
        onNavigate={handleNavigate}
        currentUser={currentUser}
        onResetData={handleResetData}
      />

      {/* TempData Banner Notification (matching ASP.NET TempData["SaveResult"]) */}
      {toastMessage && (
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 w-full mt-4">
          <div className="bg-emerald-600 text-white px-4 py-3 rounded shadow-md flex items-center justify-between text-sm animate-fadeIn">
            <div className="flex items-center space-x-2">
              <CheckCircle2 className="w-5 h-5 text-white shrink-0" />
              <span className="font-semibold">{toastMessage}</span>
            </div>
            <button
              onClick={() => setToastMessage(null)}
              className="p-1 hover:bg-emerald-700 rounded transition cursor-pointer"
            >
              <X className="w-4 h-4 text-white" />
            </button>
          </div>
        </div>
      )}

      {/* Main Body Content */}
      <main className="flex-1 max-w-7xl mx-auto w-full px-4 sm:px-6 lg:px-8 py-6">
        {currentTab === 'home' && <HomeView onNavigate={handleNavigate} />}

        {currentTab === 'pcr-list' && (
          <PCRListView pcrs={pcrs} onNavigate={handleNavigate} />
        )}

        {currentTab === 'pcr-create' && (
          <PCRCreateEditView
            onNavigate={handleNavigate}
            onShowMessage={handleShowMessage}
          />
        )}

        {currentTab === 'pcr-edit' && selectedId && (
          <PCRCreateEditView
            recordId={selectedId}
            onNavigate={handleNavigate}
            onShowMessage={handleShowMessage}
          />
        )}

        {currentTab === 'pcr-detail' && selectedId && (
          <PCRDetailView recordId={selectedId} onNavigate={handleNavigate} />
        )}

        {currentTab === 'pcr-delete' && selectedId && (
          <PCRDeleteView
            recordId={selectedId}
            onNavigate={handleNavigate}
            onShowMessage={handleShowMessage}
          />
        )}

        {currentTab === 'qa-list' && (
          <QAIssuesListView issues={issues} onNavigate={handleNavigate} />
        )}

        {currentTab === 'qa-create' && (
          <QAIssueCreateView
            onNavigate={handleNavigate}
            onShowMessage={handleShowMessage}
          />
        )}

        {currentTab === 'qa-edit' && selectedId && (
          <QAIssueEditView
            issueId={selectedId}
            onNavigate={handleNavigate}
            onShowMessage={handleShowMessage}
          />
        )}

        {currentTab === 'qa-detail' && selectedId && (
          <QAIssueDetailView issueId={selectedId} onNavigate={handleNavigate} />
        )}

        {currentTab === 'qa-delete' && selectedId && (
          <QAIssueDeleteView
            issueId={selectedId}
            onNavigate={handleNavigate}
            onShowMessage={handleShowMessage}
          />
        )}
      </main>

      <Footer />
    </div>
  );
};
