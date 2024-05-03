import React from 'react'
import ReactDOM from 'react-dom/client'
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import App from './App.jsx'
import './index.css'
import login from './pages/login.jsx'
import contact from './pages/contact.jsx'
import catalogus from './pages/catalogus.jsx'
import registratie from './pages/registratie.jsx'
import RootLayout from './layout/RootLayout.jsx'


const browserRouter = createBrowserRouter([
  {path: "/", component: App},
  {path: "/login", component: login},
  {path: "/contact", component: contact},
  {path: "/catalogus", component: catalogus},
  {path: "regestratie", component: registratie},
  {path: "/Root", component: RootLayout}
])
ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={browserRouter}>
      <RootLayout />
    </RouterProvider>
  </React.StrictMode>,
)
