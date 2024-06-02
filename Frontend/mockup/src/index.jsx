import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import ReactDOM from "react-dom/client";
import App from "./App";
import ContactsPage from "./pages/ContactsPage";
import MyCollectionPage from "./pages/MyCollectionPage";
import WatchListPage from "./pages/WatchListPage";
import AboutUsPage from "./pages/AboutUsPage";
import RootLayout from "./layout/RootLayout";
import { WatchlistProvider } from "./pages/context/WatchlistContext";
import ProjectsPage from "./pages/ProjectsPage";

const router = createBrowserRouter([
  {
    element: <RootLayout />,
    children: [
      { path: "/", element: <App /> },
      { path: "/contacts", element: <ContactsPage /> },
      { path: "/my-collection", element: <MyCollectionPage /> },
      { path: "/watchlist", element: <WatchListPage /> },
      { path: "/about-us", element: <AboutUsPage /> },
      { path: "/projects", element: <ProjectsPage /> },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <WatchlistProvider>
      <RouterProvider router={router} />
    </WatchlistProvider>
  </React.StrictMode>
);
