import React from "react";
import { useState } from "react";
import { Typography, Container } from "@mui/material";

import CardsContainer from "./components/CardsContainer";

const App = () => {
  const [watchlist, setWatchlist] = useState([]);

  return (
    <>
      {/* Hier zorgen we ervoor dat een gebruiker een auto kan toevoegen zegmaar aan zijn catalogus */}

      {/* main gedeelte van de applicatie */}
      <main>
        <div style={{ padding: "20px" }}>
          <Container maxWidth="sm">
            <Typography
              variant="h2"
              align="center"
              color="textPrimary"
              gutterBottom
            >
              Car Rental
            </Typography>
            <Typography variant="h6" align="center" color="textSecondary">
              This is a longer paragraph wich is actually a Typography that is a
              fancy word for any text related element from html, I think the
              sentance is long enough. bla bla bla
            </Typography>
          </Container>
        </div>
        {/* container voor onze 'Cards" */}
        {/* <CardsContainer /> */}
        <CardsContainer watchlist={watchlist} setWatchlist={setWatchlist} />
      </main>
    </>
  );
};

export default App;
