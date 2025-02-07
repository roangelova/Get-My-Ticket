import { BrowserRouter, Route, Routes } from 'react-router-dom';

import RegisterForm from './components/account/RegisterForm';
import RegisterPopUp from './components/account/RegisterPopUp';
import NotFoundPage from './components/common/NotFoundPage';
import MainPage from './components/pages/MainPage';
import SearchResultsPage from './components/pages/SearchResultsPage';
import { ToastContainer } from 'react-toastify';

function App() {
  return (
    <BrowserRouter>
      <ToastContainer />
      <Routes>
        <Route index path="/" element={< MainPage />} />
        <Route path="/register" element={<RegisterPopUp />} />
        <Route path="/register-form" element={<RegisterForm />} />
        <Route path="/search-results" element={<SearchResultsPage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;


//Structure (HOMEPAGE): 
//
//Header 60VH 
// Search Bar -> should overlap a tiny portion of the header
// CTA section Logos -> display provider logos and link to main booking page
// WHY US SECTION -> 3 reasons to choose us
// ..
// ..
//ABOUT US & FOOTER 