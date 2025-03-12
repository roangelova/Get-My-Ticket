import { BrowserRouter, Route, Routes } from 'react-router-dom';

import RegisterPopUp from './features/account/RegisterPopUp';
import NotFoundPage from './features/common/NotFoundPage';
import RegisterForm from './features/account/RegisterForm';
import MainPage from './features/pages/MainPage';
import SearchResultsPage from './features/pages/SearchResultsPage';
import Cart from './features/cart/Cart';

import { ToastContainer } from 'react-toastify';

function App() {

  return (
    <BrowserRouter>
      <ToastContainer />
      <Routes>
        <Route index path="/" element={< MainPage />} />
        <Route path="/register" element={<RegisterPopUp />} />
        <Route path="/cart" element={<Cart />} />
        <Route path="/register-form" element={<RegisterForm />} />
        <Route path="/search-results" element={<SearchResultsPage />} />
        <Route path='/user' element={<p>User page</p>}>
          <Route path='bookings' element={<p>my user bookings</p>}/>
          <Route path='profile' element={<p>my user profile</p>}/>
        </Route>
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;