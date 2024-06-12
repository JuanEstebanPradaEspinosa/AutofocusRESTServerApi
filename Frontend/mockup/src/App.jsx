import React, { useState } from "react";
import { Typography, Container } from "@mui/material";
import CardsContainer from "./components/CardsContainer";
import SearchBar from "./components/SearchBar";
import autofocusBanner from "./images/why-kei-8e2gal_GIE8-unsplash.jpg";

const App = () => {
  const [watchlist, setWatchlist] = useState([]);

  return (
    <>
      {/* main gedeelte van de applicatie */}
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
          </Container>
          {/* Searchbar met autocomplete functionaliteit (altans dat is de bedoeling)*/}
        </div>
        <div style={{ padding: "20px" }}>
          <SearchBar />
        </div>
        {/* container voor onze 'Cards' */}
        <CardsContainer watchlist={watchlist} setWatchlist={setWatchlist} />
      </main>
    </>
  );
};

export default App;
