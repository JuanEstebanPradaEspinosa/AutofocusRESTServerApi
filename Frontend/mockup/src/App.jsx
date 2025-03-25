// eslint-disable-next-line no-unused-vars
import React, { useState } from "react";
import { Typography, Container } from "@mui/material";
import CardsContainer from "./components/CardsContainer";
import SearchBar from "./components/SearchBar";
import autofocusBanner from "./images/why-kei-8e2gal_GIE8-unsplash.jpg";
import NewsLetterSection from "./components/PageSections/NewsLetterSection";
import PricingSection from "./components/PageSections/PricingSection";
import Testimonials from "./components/Testimonials";

const App = () => {
  const [watchlist, setWatchlist] = useState([]);

  return (
    <>
      <main>
        <div
          style={{
            position: "relative",
            padding: "20px",
            backgroundImage: `url(${autofocusBanner})`,
            backgroundSize: "cover",
            backgroundPosition: "center",
            color: "white",
            textAlign: "center",
            height: "400px",
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
          }}
        >
          <div
            style={{
              position: "absolute",
              top: 0,
              left: 0,
              right: 0,
              bottom: 0,
              backgroundColor: "rgba(0, 0, 0, 0.5)",
              zIndex: 1,
            }}
          ></div>
          <Container maxWidth="sm" style={{ zIndex: 2 }}>
            <Typography
              variant="h2"
              align="center"
              color="inherit"
              gutterBottom
            >
              AutoFocus
            </Typography>
            <Typography variant="h6" align="center" color="inherit">
              This is a longer paragraph which is actually a Typography that is
              a fancy word for any text related element from HTML. I think the
              sentence is long enough. bla bla bla
            </Typography>
            <div className="mt-10 flex items-center justify-center gap-x-6">
              <a
                href="#"
                className="rounded-md bg-blue-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600"
              >
                Get started
              </a>
              <a
                href="#"
                className="text-sm font-semibold leading-6 text-white hover:text-blue-500"
              >
                Learn more <span aria-hidden="true">→</span>
              </a>
            </div>
          </Container>
        </div>
        <div style={{ padding: "20px" }}>
          <SearchBar />
        </div>
        <CardsContainer watchlist={watchlist} setWatchlist={setWatchlist} />
        <NewsLetterSection />
        <PricingSection />
        <Testimonials />
      </main>
    </>
  );
};

export default App;
