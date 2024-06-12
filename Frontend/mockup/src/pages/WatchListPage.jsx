// eslint-disable-next-line no-unused-vars
import React, { useContext } from "react";
import {
  Container,
  Typography,
  Grid,
  Card,
  CardMedia,
  CardContent,
  IconButton,
  Box,
} from "@mui/material";
import WatchlistContext from "../context/WatchlistContext";
import { BookmarkRemove } from "@mui/icons-material";

const WatchListPage = () => {
  const { watchlist, setWatchlist } = useContext(WatchlistContext);

  const handleRemoveBookmark = (card) => {
    setWatchlist(watchlist.filter((item) => item !== card));
  };

  // If watchlist is undefined, initialize it with an empty array (fallback)
  if (!watchlist) {
    return <Typography variant="h6">Loading...</Typography>;
  }

  return (
    <Container style={{ padding: "20px 0" }} maxWidth="md">
      <Typography variant="h4" gutterBottom>
        Bookmarked:
      </Typography>
      {/* Wanneer er geen items zijn gaan we dit ook zeggen op de pagina! */}
      {watchlist.length === 0 ? (
        <Box
          display="flex"
          justifyContent="center"
          alignItems="center"
          minHeight="60vh"
          flexDirection="column"
          textAlign="center"
        >
          <Typography variant="h6" color="textSecondary">
            Your watchlist is empty.
          </Typography>
          <Typography variant="body1" color="textSecondary">
            Add cars to your watchlist by clicking on the bookmark icon on the
            cards.
          </Typography>
        </Box>
      ) : (
        <Grid container spacing={4}>
          {watchlist.map((card) => (
            <Grid item key={card} xs={12} sm={6} md={4}>
              <Card
                style={{
                  height: "100%",
                  display: "flex",
                  flexDirection: "column",
                }}
              >
                <CardMedia
                  style={{ paddingTop: "56.25%" }}
                  image="https://source.unsplash.com/random?car"
                  title="Image title"
                />
                <CardContent style={{ flexGrow: 1 }}>
                  <Typography gutterBottom variant="h5">
                    Heading {card}
                  </Typography>
                  <Typography>
                    This card is in your watchlist. Bla bla bla.
                  </Typography>
                  <IconButton
                    onClick={() => handleRemoveBookmark(card)}
                    style={{ alignSelf: "flex-end" }}
                  >
                    <BookmarkRemove color="primary" />
                  </IconButton>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      )}
    </Container>
  );
};

export default WatchListPage;
