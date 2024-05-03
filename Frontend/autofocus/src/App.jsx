import React from "react";
import {
  Typography,
  AppBar,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  CssBaseline,
  Grid,
  Toolbar,
  Container,
  Button,
} from "@mui/material";
import { CarRental } from "@mui/icons-material";
import { palette } from "@mui/system";

import { makeStyles } from "@mui/material/styles";

/*const useStyles = makeStyles((theme) => ({
   container: {
     backgroundColor: theme.palette.background.paper,
     padding: theme.spacing(8, 0, 6),
   },
   icon: {
     marginRight: "20px",
   },
   buttons: {
     marginTop: "40px",
   },
 }));*/
const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];

const App = () => {
  //const classes = useStyles();
  return (
    <>
      <CssBaseline />
      {/* main gedeelte van de applicatie */}
      <main>
        <div>
          <Container maxWidth="sm">
            <Typography
              variant="h2"
              align="center"
              color="textPrimary"
              gutterBottom
            >
              Car Rental
            </Typography>
            <Typography variant="h5" align="center" color="textSecondary">
              This is a longer paragraph wich is actually a Typography that is a
              fancy word for any text related element from html I think the
              sentance is long enough. bla bla bla
            </Typography>
            <div>
              <Grid container spacing={2} justifyContent="center">
                <Grid item>
                  <Button
                    variant="contained"
                    color="primary"
                    style={{ marginTop: "40px" }}
                  >
                    Register here
                  </Button>
                </Grid>
                <Grid item>
                  <Button
                    variant="outlined"
                    color="primary"
                    style={{ marginTop: "40px" }}
                  >
                    Logged in yet?
                  </Button>
                </Grid>
              </Grid>
            </div>
          </Container>
        </div>
        {/* container voor onze 'Cards" */}
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
                    style={{ paddingTop: "56.25%" }}
                    image="https://source.unsplash.com/random"
                    title="Image title"
                  />
                  <CardContent style={{ flexGrow: 1 }}>
                    <Typography gutterBottom variant="h5">
                      Heading
                    </Typography>
                    <Typography>
                      Je kan deze sectie gebruiken om de content van de card te
                      beschrijven. bla bla bla
                    </Typography>
                  </CardContent>
                  <CardActions>
                    <Button size="small" color="primary">
                      View details
                    </Button>
                    <Button size="small" color="primary">
                      Send message
                    </Button>
                  </CardActions>
                </Card>
              </Grid>
            ))}
          </Grid>
        </Container>
      </main>
    </>
  );
};

export default App;
