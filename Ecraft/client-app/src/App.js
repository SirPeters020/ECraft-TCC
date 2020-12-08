import React from 'react'
import { ThemeProvider } from '@material-ui/core/styles'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { Provider } from 'react-redux'

import GuestRout from './routes/GuestRout'
import theme from './theme'
import SignIn from './pages/SignIn'
import SignUp from './pages/SignUp'
import Home from './pages/Home'
import store from './store'
import Auth from './components/Auth'


// import './mock'

function App() {
  return (
    <Provider store={store}>
    <ThemeProvider theme={theme}>
      <BrowserRouter>
      <Auth>
        <Routes>
          <GuestRout path="/login" element={<SignIn />} />
          <GuestRout path="/sign-up" element={<SignUp />} />
          <Route path="//*" element={<Home/>} />
        </Routes>
      </Auth>
      </BrowserRouter>
    </ThemeProvider>
    </Provider>
  );
}

export default App;
