import React from "react";
import { useContext } from "react";
import {
  Typography,
  Container,
  Grid,
  Card,
  CardActions,
  CardMedia,
  CardContent,
  IconButton,
} from "@mui/material";
import BookmarkBorderIcon from "@mui/icons-material/BookmarkBorder";
import BookmarkIcon from "@mui/icons-material/Bookmark";

import DetailsDialog from "./DetailsDialog";
import MessageDialog from "./MessageDialog";
import WatchlistContext from "../context/WatchlistContext";

const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];

const CardsContainer = () => {
  const { watchlist, setWatchlist } = useContext(WatchlistContext);

  const handleToggleBookmark = (card) => {
    if (watchlist.includes(card)) {
      setWatchlist(watchlist.filter((item) => item !== card));
    } else {
      setWatchlist([...watchlist, card]);
    }
  };

  return (
    <Container style={{ padding: "20px 0" }} maxWidth="md">
      <Grid container spacing={4}>
        {/* Grid item is 1 volledige mediacard */}
        {cards.map((card) => (
          <Grid item key={card} xs={12} sm={6} md={4}>
            <Card
              style={{
                height: "100%",
                display: "flex",
                flexDirection: "column",
              }}
            >
              <CardMedia
                className="card-media"
                style={{ paddingTop: "56.25%" }}
                image="https://source.unsplash.com/random?car"
                title="Image title"
              />
              <CardContent style={{ flexGrow: 1 }}>
                <Typography gutterBottom variant="h5">
                  Heading {card}
                </Typography>
                <Typography>
                  Je kan deze sectie gebruiken om de content van de card te
                  beschrijven. bla bla bla
                </Typography>
              </CardContent>
              <CardActions>
                <DetailsDialog imageUrl="https://source.unsplash.com/random?car" />
                <MessageDialog imageUrl="https://source.unsplash.com/random?" />
                <IconButton onClick={() => handleToggleBookmark(card)}>
                  {watchlist.includes(card) ? (
                    <BookmarkIcon color="primary" />
                  ) : (
                    <BookmarkBorderIcon color="primary" />
                  )}
                </IconButton>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default CardsContainer;
