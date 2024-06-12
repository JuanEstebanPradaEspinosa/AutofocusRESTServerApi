import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import ReactDOM from "react-dom/client";
import App from "./App";
import ContactsPage from "./pages/ContactsPage";
import WallPage from "./pages/WallPage";
import MyCollectionPage from "./pages/MyCollectionPage";
import WatchListPage from "./pages/WatchListPage";
import AboutUsPage from "./pages/AboutUsPage";
import RootLayout from "./layout/RootLayout";
import { WatchlistProvider } from "./context/WatchlistContext";
import ProjectsPage from "./pages/ProjectsPage";
import AuthPage from "./pages/AuthPage";
import ErrorPage from "./pages/ErrorPage";
import "./index.css";

const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    errorElement: <ErrorPage />,
    children: [
<<<<<<< HEAD
      { index: true, element: <App /> },
=======
      { path: "/", element: <App /> },
      { path: "/wall", element: <WallPage /> },
>>>>>>> ffcb25be046363e4ccb1f0527af2188d5f519bff
      { path: "/contacts", element: <ContactsPage /> },
      { path: "/my-collection", element: <MyCollectionPage /> },
      { path: "/watchlist", element: <WatchListPage /> },
      { path: "/about-us", element: <AboutUsPage /> },
      { path: "/projects", element: <ProjectsPage /> },
    ],
  },
  {
    path: "/login",
    element: <AuthPage />,
  },
  {
    path: "/register",
    element: <AuthPage />,
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <WatchlistProvider>
      <RouterProvider router={router} />
    </WatchlistProvider>
  </React.StrictMode>
);
