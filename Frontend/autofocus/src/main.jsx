import React from "react";
import ReactDOM from "react-dom/client";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import App from "./App.jsx";
import "./index.css";
import RootLayout from "./layout/RootLayout.jsx";

import LoginPage from "./pages/LoginPage.jsx";
import ContactPage from "./pages/ContactPage.jsx";
import CatalogusPage from "./pages/CatalogusPage.jsx";
import RegistratiePage from "./pages/RegistratiePage.jsx";

const browserRouter = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    children: [
      {
        index: true,
        element: <App />,
      },
      {
        path: "/login",
        element: <LoginPage />,
      },
      {
        path: "/contact",
        element: <ContactPage />,
      },
      {
        path: "/catalogus",
        element: <CatalogusPage />,
      },
      {
        path: "/registratie",
        element: <RegistratiePage />,
      },
    ],
  },
]);
ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={browserRouter}></RouterProvider>
  </React.StrictMode>
);
